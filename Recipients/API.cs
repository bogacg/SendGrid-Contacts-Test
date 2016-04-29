using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Sendgrid.Contacts.Recipients
{
    class API
    {

        public const String Endpoint = "https://api.sendgrid.com/v3/contactdb/recipients";
        private readonly HttpClient _client;
        private readonly string _apiKey;

        public API(string apiKey)
        {
            _client = new HttpClient();
            _apiKey = apiKey;

            var version = "6.3.4";

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "sendgrid/" + version + ";csharp");
            _client.Timeout = TimeSpan.FromSeconds(100);
        }

        public async Task<string> NewRecipientAsync(Recipient recipient)
        {
            List<Recipient> recipients = new List<Recipient>();
            recipients.Add(recipient);

            string json = JsonConvert.SerializeObject(recipients);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(Endpoint, content);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else
            {
                throw new Exception("ERROR");
            }
        }
    }
}
