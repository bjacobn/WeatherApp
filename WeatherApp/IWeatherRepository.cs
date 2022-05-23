using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp
{
    public interface IWeatherRepository
    {
        public WeatherModel GetWeather(string userInput);
    }
}
