using Microsoft.AspNetCore.Mvc;
using WordstageWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WordstageWeb.Repository;
using WordstageWeb.Services;

namespace WordstageWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomerepository _homerepository = new Homeservice();
        public async Task<ActionResult> Index()
        {
            List<Language> Languagemodel = new List<Language>();

            Languagemodel = await _homerepository.LoadLanguageDropdown();
            if (Languagemodel != null || Languagemodel.Count() > 0)
            {
                ViewBag.Languages = new SelectList(Languagemodel, "LanguageId", "LanguageName");
            }
            else
            {
                Languagemodel.Insert(0, new Language() { LanguageId = "00000000-0000-0000-0000-000000000000", LanguageName = "--Select--" });
                ViewBag.Languages = new SelectList(Languagemodel, "LanguageId", "LanguageName");
            }
            return View();
        }

    }
}