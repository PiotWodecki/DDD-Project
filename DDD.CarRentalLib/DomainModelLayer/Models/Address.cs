using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using DDD.Base.DomainModelLayer.Models;
using DDD.CarRentalLib.DomainModelLayer.Services;
using DDD.CarRentalLib.InfrastuctureLayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DDD.CarRentalLib.DomainModelLayer.Models
{
    public class Address : ValueObject
    {
        //To jest zrobione w taki sposób, ponieważ najpierw testowałem kody pocztowe takie w których api nie zwracało ulic tylko powiat gminę itd...
        //dopiero potem zauważyłem że dla innych kodów pocztowych api zwraca inną strukturę
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
        [JsonProperty(propertyName: "ulica")]
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

        public List<Address> GetAddressesByPostalCode(PostalCode postalCode)
        {
            var list = new List<Address>();
            var addresses = AddressByPostalService.GetLocalitiesByPostalCode(postalCode);

            foreach (var address in addresses)
            {
                list.Add(new Address
                {
                    PostalCode = postalCode,
                    County = address.County,
                    Province = address.Province,
                    Parish = address.Parish,
                    Locality = address.Locality,
                    Street = address.Street
                });
            }

            return list;
        }

        public override string ToString()
        {
            return $"Address: \n " +
                   $"Country: {Country} \n" +
                   $"County: {County}\n" +
                   $"Street: {Street}\n" +
                   $"Province: {Province}\n" +
                   $"Parish: {Parish}\n" +
                   $"Locality: {Locality}\n" +
                   $"Building number:{BuildingNumber}\n" +
                   $"Local number: {LocalNumber}\n" +
                   $"Postal code: {PostalCode}\n";
        }
    }
}
