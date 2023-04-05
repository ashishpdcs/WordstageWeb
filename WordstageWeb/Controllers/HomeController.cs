using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;
using WordstageWeb.Models;
using WordstageWeb.Models.Language;
using Newtonsoft.Json;
using WordstageWeb.Models.Login;
using Nancy.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nancy;
using System.Reflection;
using Nancy.Responses;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Security.Cryptography;

namespace WordstageWeb.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {

            var myObject = new
            {
                GlobalSearch = "",
                PageSize = 0,
                PageIndex = 0,
                OrderBy = "",
                OrderDirection = "",
            };

            JsonContent content = JsonContent.Create(myObject);

            string apiUrl = "https://wordstageapi.azurewebsites.net/api/Language/GetAllLanguageName";
            using (HttpClient client = new HttpClient())
            {
                List<Language> model = new List<Language>();
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsync(apiUrl, content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse)["Data"]);
                    model = JsonConvert.DeserializeObject<List<Language>>(details).ToList();

                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    //model = new JavaScriptSerializer().Deserialize<List<Language>>(data);

                    // ViewBag.Accounts = new SelectList(db.Accounts, "AccountId", "AccountName");
                   
                    ViewBag.Languages = new SelectList(model, "LanguageId", "LanguageName");
                }

            }
            return View();
        }

    }
}