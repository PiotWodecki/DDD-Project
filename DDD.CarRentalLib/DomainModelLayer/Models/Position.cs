using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.DomainModelLayer.Models;

namespace DDD.CarRentalLib.DomainModelLayer.Models
{
    public class Position : ValueObject
    {
        public double XPosition { get; set; }
        public double YPosition { get; set; }
        public DistanceUnit Distanceunit { get; set; }

        public Position(double xPosition, double yPosition, DistanceUnit distanceUnit)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Distanceunit = distanceUnit;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return XPosition;
            yield return YPosition;
            yield return Distanceunit;
        }

        public Distance CalculateDistance(Position position)
        {
            double distance = 0;
            if (position.Distanceunit == this.Distanceunit)
            {
                distance = (Math.Pow(XPosition - position.XPosition, 2) + Math.Pow(YPosition - position.YPosition, 2));
            }
            else if(position.Distanceunit == DistanceUnit.Kilometers && this.Distanceunit == DistanceUnit.Miles)
            {
                distance = (Math.Pow(XPosition - position.XPosition, 2) + Math.Pow(YPosition - position.YPosition, 2));
                Distance.ConvertFromMilesToKms(distance);
            }
            else
            {
                distance = (Math.Pow(XPosition - position.XPosition, 2) + Math.Pow(YPosition - position.YPosition, 2));
                Distance.ConvertFromKmsToMiles(distance);
            }

            return new Distance(distance, position.Distanceunit);

        }

    }
}
