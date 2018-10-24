using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WeatherApp.Core
{
    public class Weather
    {
        public string Temperature { get; set; } = " ";
        public string Pressure { get; set; } = " ";
        public string Wind { get; set; } = " ";
        public string City { get; set; } = " ";
        public string Tempavg { get; set; } = " ";
        public string ImageName { get; set; } = " "; //1
        public string AirPressure { get; set; } = " ";
        public string Date { get; set; } = " ";
        public string Main { get; set; } = " ";
    }
}