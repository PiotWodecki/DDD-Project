using System;
using System.Collections.Generic;
using System.Text;
using DDD.CarRentalLib.DomainModelLayer.Interfaces;

namespace DDD.CarRentalLib.DomainModelLayer.Policies
{
    public class PremiumPolicy : IFreeMinutesPolicy
    {
        public int CalculateFreeMinutes(double totalMinutes)
        {
            int freeMinutes = (int)Math.Ceiling(totalMinutes / 4);

            return freeMinutes;
        }
    }
}
