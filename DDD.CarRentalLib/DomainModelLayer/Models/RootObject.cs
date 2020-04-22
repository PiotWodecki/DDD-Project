using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace DDD.CarRentalLib.DomainModelLayer.Models
{
    public class RootObject
    {
        private List<Address> addresses { get; set; }

        public IEnumerable<Address> GetLocalitiesByPostalCode(PostalCode postalCode)
        {
            List<Address> localities = new List<Address>();

            Uri url = new Uri("http://kodpocztowy.intami.pl/api/" + $"{ postalCode.FirstPart }-{postalCode.SecondPart}");
            WebClient webClient = new WebClient();
            webClient.DownloadFile(url, "localities.json");

            using (StreamReader r = new StreamReader(Path.Combine(Environment.CurrentDirectory, "localities.json")))
            {
                var json = r.ReadToEnd();
                var data = JArray.Parse(json);
                this.addresses = data.ToObject<List<Address>>();
                //json = json.Replace("kod", "kod")
                //    .Replace("miejscowosc", "miejscowosc")
                //    .Replace("gmina", "gmina")
                //    .Replace("powiat", "powiat")
                //    .Replace("wojewodztwo", "wojewodztwo");

                //JsonSerializer serializer = new JsonSerializer();
                //using (StreamWriter sw = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"localities2.json")))
                //using (JsonWriter writer = new JsonTextWriter(sw))
                //{
                //    serializer.Serialize(writer, json);
                //}  

                //localities = JsonConvert.DeserializeObject<List<Address>>(data);

                //json = json.Replace("kod", "kod")
                //    .Replace("miejscowosc", "miejscowosc")
                //    .Replace("gmina", "gmina")
                //    .Replace("powiat", "powiat")
                //    .Replace("wojewodztwo", "wojewodztwo")
                //    .Replace(@"\", "")
                //    .Replace("\n", "")
                //    .Replace(@"\", "");
                ////    .Remove(0,1);

                //json = json.Remove(json.Length - 1, 1);
                //var tmp = JsonConvert.DeserializeObject<Address>(json);
            }

            return localities;
        }
    }
}
