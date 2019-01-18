using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ContactFormGoogleReCaptureV3.Models;
using Newtonsoft.Json;

namespace ContactFormGoogleReCaptureV3.Controllers
{
    public class ContactUsController : Controller
    {

        public class CaptchaResponseViewModel
        {
            public bool Success { get; set; }

            [JsonProperty(PropertyName = "error-codes")]
            public IEnumerable<string> ErrorCodes { get; set; }

            [JsonProperty(PropertyName = "challenge_ts")]
            public DateTime ChallengeTime { get; set; }

            public string HostName { get; set; }
            public double Score { get; set; }
            public string Action { get; set; }
        }


        // GET: ContactUs
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(ContactUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isCaptchaValid = await IsCaptchaValid(model.GoogleCaptchaToken);
                if(isCaptchaValid)
                {
                    // send email
                    return RedirectToAction("Success");
                }
                else
                {
                    ModelState.AddModelError("GoogleCaptcha", "The captcha is not valid");
                }

            }

            return View(model);
        }

        private async Task<bool> IsCaptchaValid(string response)
        {
            try
            {
                var secret = "6LcHpYoUAAAAAIQTMx-RL3WjsTN9k710FPn-DpOw";
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                    {
                        {"secret", secret},
                        {"response", response},
                        {"remoteip", Request.UserHostAddress}
                    };

                    var content = new FormUrlEncodedContent(values);
                    var verify = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", content);
                    var captchaResponseJson = await verify.Content.ReadAsStringAsync();
                    var captchaResult = JsonConvert.DeserializeObject<CaptchaResponseViewModel>(captchaResponseJson);
                    return captchaResult.Success
                           && captchaResult.Action == "contact_us"
                           && captchaResult.Score > 0.5;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public ActionResult Success()
        {
            return View();
        }
    }
}