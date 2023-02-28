using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp
{
    public interface IContactUsRepository
    {
        public Task<int> InsertContactAsync(ContactUsModel contactToInsert);
    }
}
