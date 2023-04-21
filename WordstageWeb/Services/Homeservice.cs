using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using WordstageWeb.Repository;
using WordstageWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;

namespace WordstageWeb.Services
{
    public class Homeservice : IHomerepository
    {
        public async Task<List<ProductType>> LoadProductDropdown()
        {
            var myObject = new { };

            JsonContent content = JsonContent.Create(myObject);
            //live url = https://wordstageapi.azurewebsites.net
            string apiUrl = "https://wordstageapi.azurewebsites.net/api/ProductType/GetAllProductType";
            using (HttpClient client = new HttpClient())
            {
                List<ProductType> model = new List<ProductType>();
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsync(apiUrl, content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse)["Data"]);
                    model = JsonConvert.DeserializeObject<List<ProductType>>(details).ToList();
                }
                return model;
            }
        }

        public async Task<List<Language>> LoadLanguageDropdown()
        {
            var myObject = new { };

            JsonContent content = JsonContent.Create(myObject);
            //live url = https://wordstageapi.azurewebsites.net
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
                }
                return model;
            }
        }

        public async Task<List<Product>> LoadProduct(string Productid,string from, string to)
        {
            var myObject = new {
                ProductTypeId = Productid,
                FromLanguage = from,
                ToLanguage = to
            };

            JsonContent content = JsonContent.Create(myObject);
            //live url = https://wordstageapi.azurewebsites.net
            string apiUrl = "https://wordstageapi.azurewebsites.net/api/Product/GetAllProduct";
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

        public async Task<List<ProductService>> LoadProductservices(string productid)
        {
            var myObject = new
            {
                ProductId = productid,
            };

            JsonContent content = JsonContent.Create(myObject);
            //live url = https://wordstageapi.azurewebsites.net
            //Local url = https://localhost:7256
            string apiUrl = "https://wordstageapi.azurewebsites.net/api/ProductServiceService/GetAllProductServiceService";
            using (HttpClient client = new HttpClient())
            {
                List<ProductService> model = new List<ProductService>();
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsync(apiUrl, content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse)["Data"]);
                    model = JsonConvert.DeserializeObject<List<ProductService>>(details).ToList();
                }
                return model;
            }
        }
    }
}
