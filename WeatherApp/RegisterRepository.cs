using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly IDbConnection _conn;

        public RegisterRepository(IDbConnection conn)
        {
            _conn = conn;

        }


        public int InsertUser(RegisterModel UserToInsert)
        {
            int s = _conn.Execute("INSERT INTO userdata (FirstName, LastName,Email,Password) VALUES(@fname, @lname,@email,@password); ",
                new { fname = UserToInsert.FirstName, lname = UserToInsert.LastName, email = UserToInsert.Email, password = UserToInsert.Password });
            return s;
        }

        public bool IsEmailExist(string email)
        {
            var count = _conn.ExecuteScalar<int>("SELECT COUNT(*) FROM userdata WHERE Email ='" + email + "' ");
            if (count > 0)
                return false; // already registered

                return true;  // avaiable for registraion
        }
    }
}
