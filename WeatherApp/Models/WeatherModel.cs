using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class WeatherModel
    {
        public string Country { get; set; }
        public string city { get; set; }
        public string Region { get; set; }
        public string Timezone_id { get; set; }
        public string Woeid { get; set; }

        public string temperature { get; set; }
        public string atmosphere { get; set; }
        public string condition { get; set; }
        
    }
}

