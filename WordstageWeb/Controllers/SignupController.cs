using Microsoft.AspNetCore.Mvc;
using WordstageWeb.Repository;
using WordstageWeb.Services;

namespace WordstageWeb.Controllers
{
    public class SignupController : Controller
    {
        readonly ISignuprepository _signUpRepository = new Signupservice();

        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(string firstname, string lastname, string emailAddress, string password)
        {
          
               if(ModelState.IsValid)
            {
                var Userinfo = await _signUpRepository.SignUp(firstname, lastname, emailAddress, password);
                if (Userinfo)
                {
                    Console.WriteLine("Succesfully register");
                    return RedirectToAction("Login", "Login");
                    //return View();
                }
                else
                {

                    TempData["Warning"] = "Please Input Username & Password";

                }
             
            }
            else
            {
                return View();
            }
            return View();
        }
    }
}
