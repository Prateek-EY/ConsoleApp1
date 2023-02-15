using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ConsoleApp1
{
    internal class CityResponse
    {
        [JsonProperty("latitude")]
        public string latitude { get; set; }
        [JsonProperty("longitude")]
        public string longitude { get; set; }

        [JsonProperty("current_weather")]
        public CurrentWeather _currentWeather { get; set; }


    }

    public class CurrentWeather
    {
        [JsonProperty("temperature")]
        public string temperature{ get; set; }
        [JsonProperty("windspeed")]
        public string windspeed { get; set; }
        [JsonProperty("winddirection")]
        public string winddirection { get; set; }
        [JsonProperty("weathercode")]
        public string weathercode { get; set; }

        [JsonProperty("time")]
        public DateTime dateTime { get; set; }

    }
}
