using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult ViewWeather(string country)
        {

            var repo = new WeatherRepository();
            var weather = repo.GetWeather(country);
            

            if (weather.Country == null)
            {

                ViewBag.Error = "Error";
                ViewBag.Search = country;

                return View("../Home/Index");
            }
            return View(weather);
        }
    }
}







