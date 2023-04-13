using Microsoft.AspNetCore.Mvc;

namespace WordstageWeb.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Services()
        {
            return View();
        }
    }
}
