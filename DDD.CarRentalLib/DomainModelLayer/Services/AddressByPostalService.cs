using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DDD.CarRentalLib.DomainModelLayer.Models;
using DDD.CarRentalLib.InfrastuctureLayer;
using Newtonsoft.Json.Linq;

namespace DDD.CarRentalLib.DomainModelLayer.Services
{
    public class AddressByPostalService
    {
        public static List<Address> GetLocalitiesByPostalCode(PostalCode postalCode)
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
