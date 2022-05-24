using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp
{
    public interface IRegisterRepository
    {
        public int InsertUser(RegisterModel UserToInsert);
    }
}