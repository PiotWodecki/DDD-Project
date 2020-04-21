using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.DomainModelLayer.Models;

namespace DDD.CarRentalLib.DomainModelLayer.Models
{
    public enum DistanceUnit
    {
        Kilometers,
        Miles
    }
    public class Distance : ValueObject
    {
        public double Value { get; private set; }
        public DistanceUnit Unit { get; private set; }

        public Distance(double value, DistanceUnit unit)
        {
            Value = value;
            Unit = unit;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Unit;
        }

        public static bool operator <(Distance d, Distance d2)
        {
            return d.Compare(d2) < 0;
        }

        public static bool operator >(Distance d, Distance d2)
        {
            return d.Compare(d2) > 0;
        }

        public static bool operator <=(Distance d, Distance d2)
        {
            return d.Compare(d2) <= 0;
        }
        public static bool operator >=(Distance d, Distance d2)
        {
            return d.Compare(d2) >= 0;
        }

        private int Compare(Distance distance)
        {
            if (this.Unit == distance.Unit)
            {
                return distance.Value.CompareTo(distance.Value);
            }
            throw new Exception();
        }

        public static double ConvertFromMilesToKms(double distance)
        {
            return distance * 1.609344;
        }

        public static double ConvertFromKmsToMiles(double distance)
        {
            return distance / 1.609344;
        }

    }
}
