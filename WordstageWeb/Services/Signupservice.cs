using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using WordstageWeb.Repository;
using WordstageWeb.Models;

namespace WordstageWeb.Services
{
    public class Signupservice : ISignuprepository
    {
        public async Task<bool> SignUp(string firstName, string lastName, string emailAddress, string password)
        {
            var SignUp = new Signup()
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                Password = password,

            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(SignUp);
            var postData = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://wordstageapi.azurewebsites.net/api/UserRegister/SaveUserRegister", postData);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse)["Data"]);
                // var data = JsonConvert.DeserializeObject<SignUpresponse>(details);
                var data = JsonConvert.DeserializeObject<List<Signup>>(details).FirstOrDefault();





                return true;
            }
            return false;

        }
    }
}
