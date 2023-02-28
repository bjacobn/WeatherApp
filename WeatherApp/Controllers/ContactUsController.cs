using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class ContactUsController : Controller
    {

        private readonly IContactUsRepository _contactRepo;


        public ContactUsController(IContactUsRepository contactRepo)
        {
            _contactRepo = contactRepo;
        }


        public IActionResult ContactUs()
        {
            var viewModel = new ContactUsModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> InsertContactUsToDatabase(ContactUsModel contactToInsert)
        {
            //Validate Model
            if (!ModelState.IsValid)
            {
                return View("ContactUs", contactToInsert);
            }

            var viewModel = new ContactUsModel();

            //Check database row insertion
            int rows = await _contactRepo.InsertContactAsync(contactToInsert);
            if (rows > 0)
            {

                viewModel.Message = "Success";
                ModelState.Clear();

            }
            else
            {

                viewModel.Message = "Error";
                ModelState.Clear();
            }

            return View("ContactUs", viewModel);
        }
    }
}
