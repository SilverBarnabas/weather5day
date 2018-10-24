using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace WeatherApp.Core
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string zipCode)
        {
            string key = "a519d2565f58343b5f157d056e658aca";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?q=" + zipCode + "&APPID=" + key + "&units=metric";


            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);
            var weather = new Weather();
            weather.Temperature = (string)results["main"]["temp"] + " C";
            weather.Pressure = (string)results["main"]["pressure"] + " hPa";
            weather.Wind = (string)results["wind"]["speed"] + " m/s";
            weather.City = (string)results["name"];
            weather.Tempavg = (string)results["main"]["temp_min"] + " - " + (string)results["main"]["temp_max"] + " C";
            weather.ImageName = "_" + (string)results["weather"][0]["icon"];
            return weather;
        }
    }
}