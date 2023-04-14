using Microsoft.AspNetCore.Mvc;

namespace WordstageWeb.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Services()
        {
            ViewBag.email = HttpContext.Session.GetString("emailid");
            return View();
        }
    }
}
