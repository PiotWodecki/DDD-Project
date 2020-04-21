using System;
using System.Collections.Generic;
using System.Text;
using DDD.CarRentalLib.DomainModelLayer.Interfaces;

namespace DDD.CarRentalLib.DomainModelLayer.Policies
{
    public class StandardPolicy : IFreeMinutesPolicy
    {
        public int CalculateFreeMinutes(double totalMinutes)
        {
            int freeMinutes = (int) totalMinutes / 8;
            
            return freeMinutes;
        }
    }
}
