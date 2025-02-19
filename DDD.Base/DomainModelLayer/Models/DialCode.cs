﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DDD.Base.DomainModelLayer.Models;

namespace DDD.CarRentalLib.DomainModelLayer.Models
{
    public class DialCode : ValueObject
    {
        public static readonly string DefaultPrefix = "+48";
        public static readonly string DefaultCountry = "Poland";
        public static readonly string DefaultCode = "PL";
        public string Prefix { get; set; }
        public string Country { get; set; }
        public string Code { get; set; }

        public DialCode()
        {
            Prefix = DefaultPrefix;
            Country = DefaultCountry;
            Code = DefaultCode;
        }

        public DialCode(string prefix, string country, string code)
        {
            Prefix = prefix;
            Country = country;
            Code = code;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Prefix;
            yield return Country;
            yield return Code;
        }

    }
}
