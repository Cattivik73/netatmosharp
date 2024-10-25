using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetatmoSharp.Weather
{
    public class WeatherService: NetatmoServiceBase
    {
        public WeatherService(string clientId, string clientSecret, string accessToken, string refreshToken) : base(clientId, clientSecret, accessToken, refreshToken)
        {
        }
        public Device GetStationData(string stationName)
        {
            var res= GetDataAsync<GetStationsDataBody>("getstationsdata");
            var body = res.Result.Body;

            return body.Devices.FirstOrDefault(x => x.StationName == stationName);
        }

        //TODO: Implment other methods to get the data from the weather module /getpublicdata and  and getmeasure
    }
}
