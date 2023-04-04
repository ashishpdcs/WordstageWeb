using Microsoft.AspNetCore.Mvc;

namespace WordstageWeb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
