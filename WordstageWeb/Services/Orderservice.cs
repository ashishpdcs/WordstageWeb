using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using WordstageWeb.Repository;
using WordstageWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WordstageWeb.Services
{
    public class Orderservice : IOrderrepository
    {
        public async Task<List<Product>> GetProductDetails(string productId)
        {
            var myObject = new
            {
                productId = productId,
            };

            JsonContent content = JsonContent.Create(myObject);
            //live url = https://wordstageapi.azurewebsites.net
            string apiUrl = "https://wordstageapi.azurewebsites.net/api/Product/GetProduct";
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

    }
}
