using Microsoft.AspNetCore.Mvc;
using WordstageWeb.Models;
using WordstageWeb.Repository;
using WordstageWeb.Services;

namespace WordstageWeb.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderrepository _homerepository = new Orderservice();
        public IActionResult Order()
        {
            ViewBag.email = HttpContext.Session.GetString("emailid");
            return View();
        }
        public async Task<ActionResult> LoadProductData(string ProductId)
        {
            List<Product> products = new List<Product>();
            products = await _homerepository.GetProductDetails(ProductId);
            return Json(products);
        }
    }
}
