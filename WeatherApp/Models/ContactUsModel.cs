using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace WeatherApp.Models
{
    public class ContactUsModel
    {
        public ContactUsModel()
        {
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Feedback { get; set; }
    }
}
