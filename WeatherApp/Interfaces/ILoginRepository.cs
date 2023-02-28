using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp
{
    public interface ILoginRepository
    {
        public Task<LoginModel> GetUserAsync(string email, string password);
    }
}
