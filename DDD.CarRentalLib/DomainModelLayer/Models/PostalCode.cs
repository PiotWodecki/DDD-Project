using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using DDD.Base.DomainModelLayer.Models;

namespace DDD.CarRentalLib.DomainModelLayer.Models
{
    //[Serializable]
    public class PostalCode : ValueObject
    {
        public string FirstPart { get; set; }
        public string SecondPart { get;  set; }

        public PostalCode(string firstPart, string secondPart)
        {
            FirstPart = firstPart;
            SecondPart = secondPart;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstPart;
            yield return SecondPart;
        }

        public void GetLocalityByPostalCode(PostalCode postalCode)
        {
            Uri url = new Uri("http://kodpocztowy.intami.pl/api/" + $"{ postalCode.FirstPart }-{postalCode.SecondPart}");
            WebClient webClient = new WebClient();
            webClient.DownloadFile(url, "localities.json");
        }

        public override string ToString()
        {
            return $"{FirstPart}-{SecondPart}";
        }
    }
}
