using Microsoft.AspNetCore.Mvc;
using WordstageWeb.Repository;
using WordstageWeb.Services;

namespace WordstageWeb.Controllers
{
    public class LoginController : Controller
    {
        readonly ILoginrepository _loginRepository = new Loginservice();
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string emailid, string password)
        {

            if (ModelState.IsValid)
            {
                var Userinfo = await _loginRepository.login(emailid, password);
                if (Userinfo)
                {
                    Console.WriteLine("Succesfully register");
                    return RedirectToAction("Index", "Home");
                    //return View();
                }
                else
                {
                    Console.WriteLine("not register");

                    return View("Index");
                }

            }
            else
            {
                return View();
            }
        }
    }
}