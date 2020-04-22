using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using DDD.Base.DomainModelLayer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DDD.CarRentalLib.DomainModelLayer.Models
{
    public class Address : ValueObject
    {
        [JsonProperty(propertyName: "miejscowosc")]
        public string Locality { get; private set; }
        [JsonProperty(propertyName: "wojewodztwo")]
        public string Province { get; private set; }
        [JsonProperty(propertyName: "gmina")]
        public string Parish { get; private set; } 
        [JsonProperty(propertyName: "powiat")]
        public string County { get;  private set; }
        //[JsonProperty(propertyName: "kod")]
        private PostalCode PostalCode { get; set; }
        //{
        //    get { return PostalCode; }
        //    set
        //    {
        //        var code = value.ToString().Split('-');
        //        PostalCode.FirstPart = code[0];
        //        PostalCode.SecondPart = code[1]; //value.ToString().Substring(2, 3);
        //        this.PostalCode = new PostalCode(code[0], code[1]);
        //    }
        //}

        public Address()
        {
            
        }
        public Address(string locality, string province, string parish, string county, PostalCode postalCode)
        {
            this.Locality = locality;
            this.Province = province;
            this.Parish = parish;
            this.County = county;
            PostalCode = postalCode;
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

                foreach (var adress in localities)
                {
                    adress.PostalCode = postalCode;
                }
            }

            return localities;
        }
    }
}
