using Microsoft.AspNetCore.Mvc;

namespace WordstageWeb.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            ViewBag.email = HttpContext.Session.GetString("emailid");

            return View();
        }
    }
}
