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


        public UserController(IRegisterRepository repo)
        {
            _regRepo = repo;
        }



        //-----------Register  ---------------------//

        public IActionResult Register()
        {
            ViewBag.Message = TempData["Message"] as string;
            return View();
        }


        public IActionResult InsertUserToDatabase(RegisterModel UserToInsert)
        {
            int rows = _regRepo.InsertUser(UserToInsert);
            if (rows > 0)
            {
                TempData["Message"] = "Success";

            }
            return RedirectToAction("Register");
        }


        //-----------Login ---------------------//



        public IActionResult Login()
        {
            return View();
        }


    }

}







