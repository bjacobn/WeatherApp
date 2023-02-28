using Dapper;
using System.Data;
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

        //Store new user
        public async Task<int> InsertUserAsync(RegisterModel userToInsert)
        {
            int s = await _conn.ExecuteAsync("INSERT INTO userdata (FirstName, LastName,Email,Password) VALUES(@fname, @lname,@email,@password); ",
                new { fname = userToInsert.FirstName, lname = userToInsert.LastName, email = userToInsert.Email, password = userToInsert.Password });
            return s;
        }

        //Check if user exists
        public bool IsEmailExist(string email)
        {
            var count =  _conn.ExecuteScalar<int>("SELECT COUNT(*) FROM userdata WHERE Email ='" + email + "' ");
            if (count > 0)
                return false; // already registered

                return true;  // avaiable for registraion
        }
    }
}
