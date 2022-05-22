using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewWeather()
        {
            return View();
        }

    }
}
