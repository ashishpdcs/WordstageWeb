using Microsoft.AspNetCore.Mvc;
using Nancy.Session;
using System.Reflection;
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string emailid, string password)
        {
            if (ModelState.IsValid)
            {
                    var Userinfo = await _loginRepository.login(emailid, password);
                    if (Userinfo)
                    {
                        Console.WriteLine("Succesfully register");
                    HttpContext.Session.SetString("emailid", emailid);
                        return RedirectToAction("Index", "Home");
                        //return View();
                    }
                    else
                    {
                    ModelState.AddModelError("Password", "Invalid Email and Password");
                    return View();
                    }

                }
                else
                {
                    return View();
                }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("emailid");
            return RedirectToAction("Index","Home");
        }
    }
}