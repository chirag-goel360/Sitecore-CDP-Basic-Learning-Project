using SitecoreCDP.Foundation.Integrations.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web.Http;

namespace SitecoreCDP.Foundation.Integrations.Controllers
{
    public class IdentifyGuestController : ApiController
    {
        [Route("api/identifyguest/{id}")]
        public GuestInformation GetGuestData(string id)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("https://api.boxever.com")
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string API_KEY_ID = SitecoreCDP.Project.Website.Constants.client_key;
            string API_KEY_SECRET = SitecoreCDP.Project.Website.Constants.client_secret;
            string key = API_KEY_ID + ":" + API_KEY_SECRET;
            byte[] textBytes = Encoding.UTF8.GetBytes(key);
            string value = Convert.ToBase64String(textBytes);
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + value);
            HttpResponseMessage response = client.GetAsync("/v2/guests/" + id).Result;
            string content = string.Empty;
            using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, true))
            {
                content = stream.ReadToEnd();
            }
            GuestInformation finalResults = JsonSerializer.Deserialize<GuestInformation>(content);
            return finalResults;
        }
    }
}