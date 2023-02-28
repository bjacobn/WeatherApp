using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp
{
    public class WeatherRepository : IWeatherRepository
    {
        public async Task<WeatherModel> GetWeatherAsync(string userInput)
        {
            try
            {
                string[] countrydata = userInput.Trim().Split(',');
                var city = countrydata[0].ToString();
                var countryname = countrydata[1].ToString();

                var _key = Environment.GetEnvironmentVariable("APIKEY");

                var client = new RestClient("https://yahoo-weather5.p.rapidapi.com/weather?location=" + city + "%2C" + countryname + "&format=json&u=f");
                var request = new RestRequest(Method.GET);
                request.AddHeader("X-RapidAPI-Host", "yahoo-weather5.p.rapidapi.com");
                request.AddHeader("X-RapidAPI-Key", _key);
                var response = await client.ExecuteAsync(request);

                var weather = new WeatherModel();

                if (response.StatusCode != System.Net.HttpStatusCode.InternalServerError)
                {
                    var location = JObject.Parse(response.Content).GetValue("location");
                    var currentobservation = JObject.Parse(response.Content).GetValue("current_observation");
                    var condition = JObject.Parse(currentobservation.ToString()).GetValue("condition");
                    var atmosphere = JObject.Parse(currentobservation.ToString()).GetValue("atmosphere");


                    weather.Country = (string)location["country"];
                    weather.city = (string)location["city"];
                    weather.Woeid = (string)location["woeid"];
                    weather.Timezone_id = (string)location["timezone_id"];

                    weather.atmosphere = (string)atmosphere["humidity"];
                    weather.condition = (string)condition["text"];
                    weather.temperature = (string)condition["temperature"];

                }

                return weather;
            }
            catch (Exception ex)
            {
                return new WeatherModel();

            }
        }
    }
}
