using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp
{
    public interface IRegisterRepository
    {
        public Task<int> InsertUserAsync(RegisterModel UserToInsert);
        public bool IsEmailExist(string email);
    }
}