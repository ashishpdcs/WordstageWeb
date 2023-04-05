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
        //    public async Task<bool> (string username, string password)
        //    {
        //        var login = new Login()
        //        {
        //            emailid = username,
        //            Password = password,

        //        };
        //        var httpClient = new HttpClient();
        //        var json = JsonConvert.SerializeObject(login);
        //        var postData = new StringContent(json, Encoding.UTF8, "application/json");
        //        var response = await httpClient.PostAsync("https://wordstageapi.azurewebsites.net/api/Account/authenticate", postData);
        //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //        {
        //            var jsonResponse = await response.Content.ReadAsStringAsync();
        //            var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse)["Data"]);
        //            //var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse));

        //            var data = JsonConvert.DeserializeObject<Login>(details);

        //            return true;
        //        }
        //        return false;
        //    }
        public async Task<List<Language>> LoadLanguageDropdown()
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
                }
                return model;
            }
        }
    }
}
