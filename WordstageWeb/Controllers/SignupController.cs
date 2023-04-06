using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WordstageWeb.Models;
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
            var model = new Signup();
            model.UserTypes = new List<SelectListItem>
    {
        new SelectListItem { Text = "Customers", Value = "Customers" },
        new SelectListItem { Text = "Admin", Value = "Admin" },
        new SelectListItem { Text = "Option 3", Value = "3" }
    };
            return View(model);
           // return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(string firstname, string lastname, string emailAddress, string password, string usertype)
        {
               if(ModelState.IsValid)
            {
                var Userinfo = await _signUpRepository.SignUp(firstname, lastname, emailAddress, password, usertype);
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
