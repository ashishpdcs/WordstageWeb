using Microsoft.AspNetCore.Mvc;
using WordstageWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WordstageWeb.Repository;
using WordstageWeb.Services;
using System.Reflection;
using Nancy.Json;
using Newtonsoft.Json;

namespace WordstageWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomerepository _homerepository = new Homeservice();
        List<Language> Languagemodel = new List<Language>();
        List<ProductType> productmodel = new List<ProductType>();

        public async Task<ActionResult> Index()
        {
            Languagemodel = await _homerepository.LoadLanguageDropdown();
            ViewBag.FromLanguages = new SelectList(Languagemodel, "LanguageId", "LanguageName");
            ViewBag.ToLanguages = new SelectList(Languagemodel, "LanguageId", "LanguageName");

            productmodel = await _homerepository.LoadProductDropdown();
            var productDropdown = productmodel.Select(p => new SelectListItem
            {
                Value = p.TypeId.ToString(),
                Text = p.ProductTypeName,
            });
            ViewBag.ProductDropdown = productDropdown;
            List<SelectListItem> applicant = new List<SelectListItem>();
            applicant.Add(new SelectListItem { Value = "1", Text = "1" });
            applicant.Add(new SelectListItem { Value = "2", Text = "2" });
            applicant.Add(new SelectListItem { Value = "3", Text = "3" });
            ViewBag.noofapplicant = applicant;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> LoadProductdata(string Product, string from, string to)
        {
            List<Product> productmodel = new List<Product>();
            productmodel = await _homerepository.LoadProduct(Product,from,to);
            return Json(productmodel);
        }
    }
}