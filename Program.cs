using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sendgrid.Contacts.Recipients;

namespace Sendgrid.Contacts
{
    class Program
    {
        static void Main(string[] args)
        {
            var recipient = new Recipient();
            Console.WriteLine("Email:");
            recipient.Email = Console.ReadLine();
            Console.WriteLine("First Name:");
            recipient.FirstName = Console.ReadLine();
            Console.WriteLine("Last Name:");
            recipient.LastName = Console.ReadLine();


            var transportInstance = new Recipients.API("SENDGRID_APIKEY_GOES_HERE");
            try
            {
                var httpResp = transportInstance.NewRecipientAsync(recipient).Result;
                dynamic jsonObject = JObject.Parse(httpResp);
                //Check if we really created a new recipient
                JToken token = jsonObject["persisted_recipients"];
                if (token != null && token.Type == JTokenType.Array && token.HasValues)
                {
                    foreach (var createdID in jsonObject.persisted_recipients)
                    {
                        Console.WriteLine("\nCreated recipient's ID: {0}", createdID.ToString());
                    }

                    //From this point on, by getting jsonObject.persisted_recipients which is an array of newly created
                    //recipients' IDs, we can add those recipients to a list/segment if needed
                }

                JToken ErrorToken = jsonObject["error_count"];
                int ErrorCount = ErrorToken.Value<int>();
                if (ErrorCount > 0)
                {
                   Console.WriteLine("\nBEWARE: There were {0} errors!!", ErrorCount);
                    // Also you can read errors array and message properties of each error and print here.
                }

                Console.WriteLine("\n\nPress any key to continue.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\n\nPress any key to continue.");
                Console.ReadKey();
            }
        }
    }
}
