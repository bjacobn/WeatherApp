using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Search(string country)
        {

            var repo = new WeatherRepository();
            var weather = repo.GetWeather(country);
            TempData["Search"] = country;


            if (weather.Country == null)
            {
                TempData["Error"] = "Location not found,please try again.";
                return RedirectToAction("Index", "Home");
            }
            return View(weather);
        }
        
    }
}




