using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ecard.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ecard.Pages
{
    public class QuestionnaireModel : PageModel
    {

        // WOWOCO: 1
        [BindProperty]
        public Favorites _myFavorites { get; set; }

        // WOWOCO: 2
        private DbBridge _myDbBridge { get; set; }

        // WOWOCO: 3
        private IConfiguration _myConfiguration { get; set; }


        // WOWOCO: 4
        public QuestionnaireModel(DbBridge DbBridge, IConfiguration Configuration)
        {
            _myDbBridge = DbBridge;
            _myConfiguration = Configuration;

        }

        public void OnGet() { }

        [HttpPost]
        public async Task<IActionResult> OnPost()
        {

            if (await isValid())
            {
                if (ModelState.IsValid)
                {
                    try
                    {

                        // DB Related Customized values added with each record
                        _myFavorites.created = DateTime.Now.ToString();
                        _myFavorites.created_ip = this.HttpContext.Connection.RemoteIpAddress.ToString();

                        //Clean Data before insertion 

                        _myFavorites.friendname = _myFavorites.friendname.Replace("i", "3");
                        _myFavorites.friendname = _myFavorites.friendname.Replace("She said,\"Hello!\"", " & quot;");


                        //Clean Data before insertion 
                        _myFavorites.senderemail = _myFavorites.senderemail.ToLowerInvariant();
                        _myFavorites.friendemail = _myFavorites.friendemail.ToUpperInvariant();

                        // DB Related add record
                        _myDbBridge.Favorites.Add(_myFavorites);
                        _myDbBridge.SaveChanges();

                        //REDIRECT to the page with a new operator (name/value pair)
                        return RedirectToPage("Questionnaire", new { id = _myFavorites.ID });
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return RedirectToPage("Questionnaire");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("_myFavorites.reCaptcha", "Please verify you're not a robot!");
            }

            return Page();

        }

        /**
         * reCAPTHCA SERVER SIDE VALIDATION 
         * 
         *      Create an HttpClient and store the the secret/response pair
         *      Await for the sever to return a json obect 
         * */
        private async Task<bool> isValid()
        {
            var response = this.HttpContext.Request.Form["g-recaptcha-response"];
            if (string.IsNullOrEmpty(response))
                return false;

            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>();
                    //values.Add("secret", "SECRET KEY");
                    values.Add("secret", _myConfiguration["ReCaptcha:PrivateKey"]);

                    values.Add("response", response);
                    //values.Add("remoteip", this.HttpContext.Connection.RemoteIpAddress.ToString()); 

                    var query = new FormUrlEncodedContent(values);

                    var post = client.PostAsync("https://www.google.com/recaptcha/api/siteverify", query);

                    var json = await post.Result.Content.ReadAsStringAsync();

                    if (json == null)
                        return false;

                    var results = JsonConvert.DeserializeObject<dynamic>(json);

                    return results.success;
                }

            }
            catch { }

            return false;
        }

    }
}