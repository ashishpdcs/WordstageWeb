using Microsoft.AspNetCore.Mvc;

namespace WordstageWeb.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult ContactUs()
        {
            ViewBag.email = HttpContext.Session.GetString("emailid");

            return View();
        }
    }
}
