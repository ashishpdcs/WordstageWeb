using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using WordstageWeb.Repository;
using WordstageWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WordstageWeb.Services
{
    public class Homeservice : IHomerepository
    {
        public async Task<List<Product>> GetAllProductDetails()
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
            //live url = https://wordstageapi.azurewebsites.net
            string apiUrl = "https://localhost:7256/api/Product/GetAllProduct";
            using (HttpClient client = new HttpClient())
            {
                List<Product> model = new List<Product>();
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsync(apiUrl, content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse)["Data"]);
                    model = JsonConvert.DeserializeObject<List<Product>>(details).ToList();
                }
                return model;
            }
        }

        public async Task<List<Language>> LoadLanguageDropdown()
        {
            var myObject = new {};

            JsonContent content = JsonContent.Create(myObject);
            //live url = https://wordstageapi.azurewebsites.net
            string apiUrl = "https://localhost:7256/api/Language/GetAllLanguageName";
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
                }
                return model;
            }
        }
    }
}
