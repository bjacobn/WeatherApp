using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherRepository _weatherRepo;

        public WeatherController(IWeatherRepository weatherRepo)
        {
            _weatherRepo = weatherRepo;
        }


        [HttpGet]
        public async Task<IActionResult> ViewWeatherAsync(string country)
        {
            ViewBag.Search = country;
            var weather = await _weatherRepo.GetWeatherAsync(country);
      
            if (weather.Country == null)
            {
                ViewBag.Error = "Error";
                return View("../Home/Index");
            }

            return View(weather);
        }
    }
}
