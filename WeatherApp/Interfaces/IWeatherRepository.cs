using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp
{
    public interface IWeatherRepository
    {
        public Task<WeatherModel> GetWeatherAsync(string userInput);
    }
}
