using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using DDD.Base.DomainModelLayer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DDD.CarRentalLib.DomainModelLayer.Models
{
    public class Address : ValueObject
    {
        [JsonProperty(propertyName: "miejscowosc")]
        public string miejscowosc { get; private set; }
        [JsonProperty(propertyName: "wojewodztwo")]
        public string wojewodztwo { get; private set; } //województwo
        [JsonProperty(propertyName: "gmina")]
        public string gmina { get; private set; } //gmina
        [JsonProperty(propertyName: "powiat")]
        public string powiat { get;  private set; } //powiat
        [JsonProperty(propertyName: "kod")]
        PostalCode PostalCode
        {
            get { return PostalCode; }
            set
            {
                var code = value.ToString().Split('-');
                PostalCode.FirstPart = code[0];
                PostalCode.SecondPart = code[1]; //value.ToString().Substring(2, 3);
                this.PostalCode = new PostalCode(code[0], code[1]);
            }
        }


        public Address()
        {
            
        }
        public Address(string miejscowosc, string wojewodztwo, string gmina, string county, PostalCode kod)
        {
            this.miejscowosc = miejscowosc;
            this.wojewodztwo = wojewodztwo;
            this.gmina = gmina;
            this.powiat = powiat;
            PostalCode = kod;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }

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
                localities = data.ToObject<List<Address>>();

                //localities = JsonConvert.DeserializeObject<List<Address>>(data);
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
