using Microsoft.AspNetCore.Mvc;
using WordstageWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WordstageWeb.Repository;
using WordstageWeb.Services;
using System.Reflection;

namespace WordstageWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomerepository _homerepository = new Homeservice();
        List<Language> Languagemodel = new List<Language>();
        List<Product> productmodel = new List<Product>();
        public async Task<ActionResult> Index()
        {
            Languagemodel = await _homerepository.LoadLanguageDropdown();
            if (Languagemodel.Count() > 0)
            {
                ViewBag.Languages = new SelectList(Languagemodel, "LanguageId", "LanguageName");
            }
            else
            {
                Languagemodel.Insert(0, new Language() { LanguageId = "00000000-0000-0000-0000-000000000000", LanguageName = "--Select--" });
                ViewBag.Languages = new SelectList(Languagemodel, "LanguageId", "LanguageName");
            }
            productmodel = await _homerepository.GetAllProductDetails();
            List<Product> ProductNamelist = productmodel;
            if (ProductNamelist != null) ProductNamelist = ProductNamelist.DistinctBy(x => x.ProductName).ToList();
            ViewBag.ProductNames = new SelectList(ProductNamelist, "ProductId", "ProductName");

            return View(productmodel);
        }
    }
}