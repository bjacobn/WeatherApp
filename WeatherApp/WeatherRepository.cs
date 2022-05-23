﻿using Newtonsoft.Json.Linq;
using RestSharp;
using WeatherApp.Models;
using dotenv.net;


namespace WeatherApp
{
    public class WeatherRepository : IWeatherRepository
    {
        public WeatherModel GetWeather(string userInput)
        {

            string[] countrydata = userInput.Trim().Split(',');
            var city = countrydata[0].ToString();
            var countryname = countrydata[1].ToString();

            var envVars = DotEnv.Read();
            var _key = envVars["KEY"];

            var weather = new WeatherModel();
            var client = new RestClient("https://yahoo-weather5.p.rapidapi.com/weather?location=" + city + "%2C" + countryname + "&format=json&u=f");
            var request = new RestRequest(Method.GET);


            request.AddHeader("X-RapidAPI-Host", "yahoo-weather5.p.rapidapi.com");
            request.AddHeader("X-RapidAPI-Key", _key);
            IRestResponse response = client.Execute(request);


            if (response.StatusCode != System.Net.HttpStatusCode.InternalServerError)
            {
                var location = JObject.Parse(response.Content).GetValue("location");
                var currentobservation = JObject.Parse(response.Content).GetValue("current_observation");
                var condition = JObject.Parse(currentobservation.ToString()).GetValue("condition");

                weather.Country = (string)location["country"];
                weather.city = (string)location["city"];
                weather.Region = (string)location["region"];
                weather.Woeid = (string)location["woeid"];
                weather.Timezone_id = (string)location["timezone_id"];
                //weather.Timezone_id = (string)location["timezone_id"];

                weather.code = (string)condition["code"];
                weather.txt = (string)condition["text"];
                weather.temperature = (string)condition["temperature"];
            }

            return weather;
        }
    }
}