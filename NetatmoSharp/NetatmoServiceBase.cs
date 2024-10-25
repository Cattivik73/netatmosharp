using NetatmoSharp.Weather;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Caching;

namespace NetatmoSharp
{
    public abstract class NetatmoServiceBase : IDisposable
    {
        internal protected readonly string _clientId;
        internal protected readonly string _clientSecret;
        internal protected string _refreshToken;
        internal protected string _accessToken;
        private StatusEnum _status = StatusEnum.Inizializing;
        private static SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);
        public EventHandler<RefreshedTokenEventArgs> TokenRefrehed;
        public enum StatusEnum
        {
            Inizializing,
            Refreshing,
            Disposed,
            Error,

        }


        public NetatmoServiceBase(string clientId, string clientSecret, string accessToken, string refreshToken)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _accessToken = accessToken;
            _refreshToken = refreshToken;
            System.Threading.ThreadPool.QueueUserWorkItem(async (state) =>
            {
                bool refreshing = true;
                _status = StatusEnum.Refreshing;

                while (refreshing && (_status != StatusEnum.Disposed))
                {
                    // Refresh the token every 60 minutes
                    await Task.Delay(TimeSpan.FromMinutes(1));
                    try
                    {
                        refreshing = await RefreshAccessTokenAsync();
                    }
                    catch
                    {
                        refreshing = false;
                    }
                    if (!refreshing)
                        _status = StatusEnum.Error;
                }
            });
        }


        protected async Task<bool> RefreshAccessTokenAsync()
        {
            try
            {
                await _semaphoreSlim.WaitAsync();
                var client = new RestClient("https://api.netatmo.com");
                var request = new RestRequest("oauth2/token", Method.Post);
                request.AddParameter("grant_type", "refresh_token");
                request.AddParameter("client_id", _clientId);
                request.AddParameter("client_secret", _clientSecret);
                request.AddParameter("refresh_token", _refreshToken);

                var response = await client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    var content = Newtonsoft.Json.Linq.JObject.Parse(response.Content);

                    _accessToken = content["access_token"].ToString();
                    _refreshToken = content["refresh_token"].ToString();

                    if (TokenRefrehed != null)
                        try
                        {
                            TokenRefrehed(this, new RefreshedTokenEventArgs(_accessToken, _refreshToken));
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Error during token refresh event " + ex.Message);
                        }

                    return true;
                }
                else
                {
                    Console.WriteLine("Error during refresh of the token: " + response.Content);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during refresh of the token: " + ex.Message);
                return false;
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        protected async Task<T> GetDataAsync<T>(string action)
        {
            if (_status == StatusEnum.Error)
                throw new ApplicationException("Error during token refresh. Refresh your Access Token and Refresh token to work again");
            if (_status == StatusEnum.Disposed)
                throw new ApplicationException("Object disposed");

            var client = new RestClient("https://api.netatmo.com");
            //getstationsdata
            var request = new RestRequest($"api/{action}", Method.Get);
            try
            {
                await _semaphoreSlim.WaitAsync();
                request.AddHeader("Authorization", "Bearer " + _accessToken);
                Console.WriteLine("Authorization Bearer " + _accessToken);
                var response = await client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    string jsonResponse = response.Content;
                    T responseData = JsonConvert.DeserializeObject<T>(jsonResponse);
                    return responseData;
                }
                else
                {
                    //ErrorResponse
                    string jsonResponse = response.Content;
                    ErrorResponse responseData = JsonConvert.DeserializeObject<ErrorResponse>(jsonResponse);
                    throw new ApplicationException(responseData.Error.Message);
                }
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        public void Dispose()
        {
            _semaphoreSlim.Dispose();
            _semaphoreSlim = null;
            TokenRefrehed = null; // Remove all event listeners
            _status = StatusEnum.Disposed;
        }
    }
}
