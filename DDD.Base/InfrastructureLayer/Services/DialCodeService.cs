using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.CarRentalLib.DomainModelLayer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DDD.Base.InfrastructureLayer.Services
{
    public class DialCodeService
    {
        public static string GetAreaCodeByCountry(string country)
        {
            var code = "";
            var jsonfile = DialCodesReader.LoadJson();
            List<DialCode> dialCodes = JsonConvert.DeserializeObject<List<DialCode>>(jsonfile);
            code = dialCodes
                .Where(x => x.Country == country)
                .Select(x => x.Prefix)
                .FirstOrDefault();

            return code;
        }

        public static string GetCountryByAreaCode(string areaCode)
        {
            var code = "";
            var jsonfile = DialCodesReader.LoadJson();
            List<DialCode> dialCodes = JsonConvert.DeserializeObject<List<DialCode>>(jsonfile);
            code = dialCodes
                .Where(x => x.Prefix == areaCode)
                .Select(x => x.Country)
                .FirstOrDefault();

            return code;
        }

        public static DialCode GetDialCodeByCountry(string country)
        {
            var jsonfile = DialCodesReader.LoadJson();
            List<DialCode> dialCodes = JsonConvert.DeserializeObject<List<DialCode>>(jsonfile);
            var dialCode = dialCodes
                .Where(x => x.Country == country)
                .FirstOrDefault();

            return dialCode;
        }
    }
}
