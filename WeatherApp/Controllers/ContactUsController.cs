using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class ContactUsController : Controller
    {

        private readonly IContactUsRepository _contactRepo;


        public ContactUsController(IContactUsRepository contactRepo)
        {
            _contactRepo = contactRepo;
        }


        public IActionResult ContactUs()
        {
            return View();
        }


        [HttpPost]
        public IActionResult InsertContactUsToDatabase(ContactUsModel ContactToInsert)
        {

            int rows = _contactRepo.InsertContact(ContactToInsert);
            if (rows > 0)
            {

                ViewBag.Message = "Success";

            }
            else
            {

                ViewBag.Message = "Error";

            }

            return View("ContactUs");
        }
    }
}
