using Microsoft.AspNetCore.Mvc;
using WordstageWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WordstageWeb.Repository;
using WordstageWeb.Services;
using System.Reflection;
using Nancy.Json;
using Newtonsoft.Json;
using System;

namespace WordstageWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomerepository _homerepository = new Homeservice();
        List<Language> Languagemodel = new List<Language>();
        List<ProductType> productTypes = new List<ProductType>();
        List<RequireHardCopy> requireHardCopymodel = new List<RequireHardCopy>();
        List<ProductService> productServices = new List<ProductService>();
        public async Task<ActionResult> Index()
        {
            Languagemodel = await _homerepository.LoadLanguageDropdown();
            ViewBag.FromLanguages = new SelectList(Languagemodel, "LanguageId", "LanguageName");
            ViewBag.ToLanguages = new SelectList(Languagemodel, "LanguageId", "LanguageName");

            productTypes = await _homerepository.LoadProductDropdown();
            var productDropdown = productTypes.Select(p => new SelectListItem
            {
                Value = p.TypeId.ToString(),
                Text = p.ProductTypeName,
            });
            ViewBag.ProductDropdown = productDropdown;
            ViewBag.email = HttpContext.Session.GetString("emailid");

            List<ProductType> people = productTypes; // assume this method returns a list of Person objects
            string[] names = people.Select(p => p.ProductTypeName).ToArray();
            ViewBag.RequireHardCopy = names;

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> LoadProductdata(string Product, string from, string to)
        {
            List<Product> productmodel = new List<Product>();
            productmodel = await _homerepository.LoadProduct(Product,from,to);
            return Json(productmodel);
        }
        public async Task<ActionResult> Home()
        {
            Languagemodel = await _homerepository.LoadLanguageDropdown();
            ViewBag.FromLanguages = new SelectList(Languagemodel, "LanguageId", "LanguageName");
            ViewBag.ToLanguages = new SelectList(Languagemodel, "LanguageId", "LanguageName");

            productTypes = await _homerepository.LoadProductDropdown();
            var productDropdown = productTypes.Select(p => new SelectListItem
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
            ViewBag.email = HttpContext.Session.GetString("emailid");

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> LoadProductServiceData(string ProductId)
        {
            productServices =  await _homerepository.LoadProductservices(ProductId);
            return Json(productServices);
        }
    }
}