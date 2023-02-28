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

            var viewModel = new WeatherModel();
            var weather = await _weatherRepo.GetWeatherAsync(country);


            if (weather.Country == null)
            {

                viewModel.Message = "Error";
                ViewBag.Search = country;

                return View("../Home/Index");
            }
            return View(weather);
        }
    }
}







