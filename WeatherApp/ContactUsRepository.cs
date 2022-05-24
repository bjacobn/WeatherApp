using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        //CONTACTUS - STORE IN MYSQL
        public int InsertContact(ContactUsModel ContactToInsert)
        {
            int s = _conn.Execute("INSERT INTO contact (FullName,Email/*,Phone*/,Feedback) VALUES(@fullname,@email,@feedback); ",
                new { fullname = ContactToInsert.FullName, email = ContactToInsert.Email, feedback = ContactToInsert.Feedback });
            return s;
        }
    }
}
