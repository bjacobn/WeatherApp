using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class UserController : Controller
    {

        private readonly IRegisterRepository _regRepo;


        public UserController(IRegisterRepository regRepo)
        {
            _regRepo = regRepo;
        }





        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public IActionResult InsertUserToDatabase(RegisterModel UserToInsert)
        {

            int rows = _regRepo.InsertUser(UserToInsert);
            if (rows > 0)
            {
                ViewBag.Message = "Success";

            }
            else
            {
                ViewBag.Message = "Error";
            }
            return View("Register");
        }




        public IActionResult Login()
        {
            return View();
        }

    }

}
