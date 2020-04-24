using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using DDD.CarRentalLib.DomainModelLayer.Models;

namespace DDD.CarRentalLib.InfrastuctureLayer
{
    public class DownloadHelper
    {
        //API do pobierania adresów po kodzie pocztowym
        public static void DownloadLocalitiesByPostalCode(PostalCode postalCode)
        {
            var url = new Uri($"http://kodpocztowy.intami.pl/api/{postalCode.FirstPart}-{postalCode.SecondPart}");
            var webClient = new WebClient();
            webClient.DownloadFile(url, "localities.json");
        }
    }
}
