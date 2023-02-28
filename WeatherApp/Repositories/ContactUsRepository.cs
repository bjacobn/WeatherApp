using Dapper;
using System.Data;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly IDbConnection _conn;

        public ContactUsRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        //Store message
        public async Task<int> InsertContactAsync(ContactUsModel contactToInsert)
        {
            int s = await _conn.ExecuteAsync("INSERT INTO contact (FullName,Email,Feedback) VALUES(@fullname,@email,@feedback); ",
                new { fullname = contactToInsert.FullName, email = contactToInsert.Email, feedback = contactToInsert.Feedback });
            return s;
        }
    }
}
