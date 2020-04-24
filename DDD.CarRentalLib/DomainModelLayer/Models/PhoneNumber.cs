using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.DomainModelLayer.Models;

namespace DDD.CarRentalLib.DomainModelLayer.Models
{
    public class PhoneNumber : ValueObject
    {
        public string Number { get; protected set; }
        public DialCode AreaCode { get; protected set; }

        public PhoneNumber(string number, DialCode areaCode)
        {
            Number = number;
            AreaCode = areaCode;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
            yield return AreaCode;
        }

        public override string ToString()
        {
            return $"{AreaCode}{Number}";
        }
    }
}
