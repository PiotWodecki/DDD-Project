using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using DDD.Base.DomainModelLayer.Models;
using DDD.CarRentalLib.InfrastuctureLayer;
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
        public PostalCode PostalCode { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string LocalNumber { get; set; }

        public Address()
        { }
        
        public Address(string locality, string province, string parish, string county, PostalCode postalCode,string country, string street, string buildingNumber, string localNumber)
        {
            Locality = locality;
            Province = province;
            Parish = parish;
            County = county;
            PostalCode = postalCode;
            Street = street;
            BuildingNumber = buildingNumber;
            LocalNumber = localNumber;
            County = county;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PostalCode;
            yield return County;
            yield return Locality;
            yield return Province;
            yield return Parish;
            yield return Country;
            yield return Street;
            yield return BuildingNumber;
            yield return LocalNumber;
        }

        public IEnumerable<Address> GetLocalitiesByPostalCode(PostalCode postalCode)
        {
            DownloadHelper.DownloadLocalitiesByPostalCode(postalCode);
            List<Address> localities = new List<Address>();

            using (var r = new StreamReader(Path.Combine(Environment.CurrentDirectory, "localities.json")))
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
