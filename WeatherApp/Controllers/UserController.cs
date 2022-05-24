using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

    }   
}



    



