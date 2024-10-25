using NetatmoSharp.Weather;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleNetatmo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var clientId = "64e8xxxxxxxxxxxxxxxxxx";
            var clientSecret = "cCxxxxxxxxxxxxxS2yESQCfABxxxx";
            var accessToken = "";
            var refreshToken = "";
            var fileName = "Keys.txt";
            if (File.Exists(fileName))
            {
                var keyLines = File.ReadAllLines(fileName);
                if (keyLines.Length >= 2)
                {
                    accessToken = keyLines[0];
                    refreshToken = keyLines[1];
                }
            }

            var netatmoService = new NetatmoSharp.Weather.WeatherService(clientId, clientSecret, accessToken, refreshToken);
            netatmoService.TokenRefrehed += (sender, e) =>
            {
                accessToken = e.AccessToken;
                refreshToken = e.RefreshToken;
                if (File.Exists(fileName))
                {

                    File.Copy(fileName, $"{new FileInfo(fileName).Name}{DateTime.Now.ToString("yy-MM-dd mmss")}.txt");
                    File.Delete(fileName);
                }

                File.WriteAllLines(fileName, new[] { accessToken, refreshToken });
                Console.WriteLine($"Token refreshed at {DateTime.Now} AccessToken: {e.AccessToken}");
            };
            // Get device data
            bool run = true;
            while (run)
            {
                var device = netatmoService.GetStationData("Picchetti (Indoor)");
                Thread.Sleep(10000);
            }
            Console.ReadLine();
            netatmoService.Dispose();

        }
    }
}
