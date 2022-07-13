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

        private readonly IContactUsRepository contactRepo;


        public ContactUsController(IContactUsRepository contactRepo)
        {
            this.contactRepo = contactRepo;
        }


        public IActionResult ContactUs()
        {
            return View();
        }


        [HttpPost]
        public IActionResult InsertContactUsToDatabase(ContactUsModel ContactToInsert)
        {
            //Validate Model
            if (!ModelState.IsValid)
            {
                return View("ContactUs");
            }


            //Check database row insertion
            int rows = contactRepo.InsertContact(ContactToInsert);
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

            return View("ContactUs");
        }
    }
}
