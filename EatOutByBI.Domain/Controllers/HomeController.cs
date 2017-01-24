using EatOutByBI.Domain.Models;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EatOutByBI.Domain.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {

            // Validate Google recaptcha here
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LfPcxIUAAAAABUG7Ra6l9Wpps-rMrKqrrTLqwlX";
            var client = new WebClient();
            var result = client.DownloadString(
                string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            ViewBag.Message = status ? "Google reCaptcha validation success" : "Google reCaptcha validation failed";




            if (ModelState.IsValid && status)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("timbrinkmadsen@live.se"));  // replace with valid value    "recipient@gmail.com"
                message.From = new MailAddress("EatOut040@outlook.com");  // replace with valid value
                message.Subject = "Kontakt";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "EatOut040@outlook.com",  // replace with valid value
                        Password = "Eatout17"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }

        public ActionResult Test()
        {


            return View();
        }
    }
}