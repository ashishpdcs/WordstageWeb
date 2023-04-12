using Microsoft.AspNetCore.Mvc;

namespace WordstageWeb.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
