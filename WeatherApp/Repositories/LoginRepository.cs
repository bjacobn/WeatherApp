using Dapper;
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

        //Authorize user
        public async Task<LoginModel> GetUserAsync(string email, string password)
        {
            var user = await _conn.QueryAsync<LoginModel>("SELECT * FROM userdata WHERE Email ='" + email + "' and Password='" + password + "'");

            if (user.Count() > 0)
            {
                return user.First();
            }
            return null;
        }
    }
}
