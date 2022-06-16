using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class UserController : Controller
    {

        private readonly IRegisterRepository regRepo;
        private readonly ILoginRepository loginRepo;


        public UserController(IRegisterRepository regRepo, ILoginRepository loginRepo)
        {
            this.regRepo = regRepo;
            this.loginRepo = loginRepo;
        }



        //-----------  Register  ---------------------//

        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public IActionResult InsertUserToDatabase(RegisterModel UserToInsert)
        {

            //Validate model
            if (!ModelState.IsValid)
            {
                return View("Register", UserToInsert);
            }

            //Check database row insertion
            int rows = regRepo.InsertUser(UserToInsert);
            if (rows > 0)
            {
                ViewBag.Message = "Success";
                ModelState.Clear();
            }
            else
            {
                ViewBag.Message = "Error";
                ModelState.Clear();
            }
            return View("Register");
        }



        //-------------- Login ---------------------//


        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Authorization(LoginModel data)
        {
            //Validate model
            if (!ModelState.IsValid)
            {
                return View("Login");
            }

            //Get user creditials from database
            LoginModel usr = loginRepo.GetUser(data.Email, data.Password);
            if (usr != null)
            {
                HttpContext.Session.SetString("LoginName", usr.FirstName);
                return RedirectToAction("Index", "Home");
            }

            //User creditials does not exist
            else
            {
                ViewBag.Error = "Error";
                ModelState.Clear();
                return View("Login");
            }
        }



        //---------------------Logout--------------------//


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("LoginName");
            return RedirectToAction("Index", "Home");
        }
    }
}







