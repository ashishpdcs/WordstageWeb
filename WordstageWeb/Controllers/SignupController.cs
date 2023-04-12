using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
using MailKit.Net.Smtp;
using WordstageWeb.Models;
using WordstageWeb.Repository;
using WordstageWeb.Services;

namespace WordstageWeb.Controllers
{
    public class SignupController : Controller
    {
        readonly ISignuprepository _signUpRepository = new Signupservice();

        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            var model = new Signup();
            model.UserTypes = new List<SelectListItem>
    {
        new SelectListItem { Text = "Customers", Value = "Customers" },
        new SelectListItem { Text = "Translator", Value = "Translator" }
    };
            return View(model);
            // return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(string firstname, string lastname, string emailAddress, string password, string usertype)
        {
            if (ModelState.IsValid)
            {
                var Userinfo = await _signUpRepository.SignUp(firstname, lastname, emailAddress, password, usertype);
                if (Userinfo)
                {
                    string Body;
                    MimeMessage emailMessage = new MimeMessage();

                    MailboxAddress emailFrom = new MailboxAddress("Jay", "jaybhatt.dcs@gmail.com");
                    emailMessage.From.Add(emailFrom);

                    MailboxAddress emailTo = new MailboxAddress(firstname, emailAddress);
                    emailMessage.To.Add(emailTo);

                    emailMessage.Subject = "Welcome To Worsdtag";
                    string FilePath = Directory.GetCurrentDirectory() + "~\\MailHtml\\WelcomeEmail.html";
                   // string EmailTemplateText = File.ReadAllText(FilePath)

                    /*EmailTemplateText = string.Format(EmailTemplateText, firstname, password, DateTime.Now.Date.ToShortDateString());
                    EmailTemplateText = EmailTemplateText.Replace("{0}", firstname);
                    EmailTemplateText = EmailTemplateText.Replace("{1}", password.ToString());*/

                    BodyBuilder emailBodyBuilder = new BodyBuilder();
                    //emailBodyBuilder.HtmlBody = EmailTemplateText;
                    emailBodyBuilder.HtmlBody = "<br/> Your registration completed succesfully.";

                    emailMessage.Body = emailBodyBuilder.ToMessageBody();

                    SmtpClient emailClient = new SmtpClient();
                    //emailClient.Connect(_emailSettings.Host, _emailSettings.Port, _emailSettings.UseSSL);
                    //emailClient.Authenticate(_emailSettings.EmailId, _emailSettings.Password);
                    emailClient.Connect("smtp.gmail.com", 465, true);
                    emailClient.Authenticate("jaybhatt.dcs@gmail.com", "yxmbefvzfqoybkvl");
                    emailClient.Send(emailMessage);
                    emailClient.Disconnect(true);
                    emailClient.Dispose();

                    var message = "Registration Completed. Please check your Email:" + emailAddress;
                    ViewBag.Message = message;
                    return RedirectToAction("Login", "Login");
                    //return View();
                }
               
            }
            var model = new Signup();
            model.UserTypes = new List<SelectListItem>
    {
        new SelectListItem { Text = "Customers", Value = "Customers" },
        new SelectListItem { Text = "Translator", Value = "Translator" }
    };
            return View(model);
            // return View();
        }

    }
    }

