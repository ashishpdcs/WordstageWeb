using Microsoft.AspNetCore.Mvc;

namespace WordstageWeb.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
