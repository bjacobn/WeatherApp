using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbConnection _conn;

        public LoginRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        //Dapper - Read Data from MySQL
        public LoginModel GetUser(string email, string password)
        {
            var user = _conn.Query<LoginModel>("SELECT * FROM userdata WHERE Email ='" + email + "' and Password='" + password + "'");

            if (user.Count() > 0)
            {
                return user.First();
            }
            return null;
        }
    }
}
