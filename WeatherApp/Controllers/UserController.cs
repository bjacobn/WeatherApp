using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class UserController : Controller
    {

        private readonly IRegisterRepository _regRepo;
        private readonly ILoginRepository _loginRepo;


        public UserController(IRegisterRepository regRepo, ILoginRepository loginRepo)
        {
            _regRepo = regRepo;
            _loginRepo = loginRepo;
        }


        //-----------  Register  ---------------------//

        public IActionResult Register()
        {
            var viewModel = new RegisterModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUserToDatabaseAsync(RegisterModel userToInsert)
        {

            //Validate model
            if (!ModelState.IsValid)
            {
                return View("Register", userToInsert);
            }

            var viewModel = new RegisterModel();

            //Check database row insertion
            int rows = await _regRepo.InsertUserAsync(userToInsert);
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
            return View("Register", viewModel);
        }


        //-------------- Login ---------------------//

        public IActionResult Login()
        {
            var viewModel = new LoginModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AuthorizationAsync(LoginModel auth)
        {
            //Validate model
            if (!ModelState.IsValid)
            {
                return View("Login", auth);
            }

            var viewModel = new LoginModel();

            //Login succesful
            LoginModel usr = await _loginRepo.GetUserAsync(auth.Email, auth.Password);
            if (usr != null)
            {
                HttpContext.Session.SetString("LoginName", usr.FirstName);
                return RedirectToAction("Index", "Home");
            }

            //Login failed
            else
            {
                viewModel.Message = "Error";
                ModelState.Clear();
                return View("Login", auth);
            }
        }


        //---------------------Logout--------------------//

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("LoginName");
            return RedirectToAction("Index", "Home");
        }
    }
}







