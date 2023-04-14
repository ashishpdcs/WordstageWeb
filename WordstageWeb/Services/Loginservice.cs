using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using WordstageWeb.Repository;
using WordstageWeb.Models;

namespace WordstageWeb.Services
{
    public class Loginservice: ILoginrepository
    {
        public async Task<string> login(string username, string password)
        {
            var login = new Login()
            {
                emailid = username,
                Password = password,

            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(login);
            var postData = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://wordstageapi.azurewebsites.net/api/Account/authenticate", postData);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse)["Data"]);
                //var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse));

                var data = JsonConvert.DeserializeObject<Login>(details);
                var firstName = data.Firstname;
                var lastName = data.Lastname;

                return firstName+""+ lastName;
            }
            return string.Empty;
        }
    }
}
