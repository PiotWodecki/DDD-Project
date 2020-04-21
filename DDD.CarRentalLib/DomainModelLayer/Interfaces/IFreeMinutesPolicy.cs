using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.DomainModelLayer.Interfaces
{
    public interface IFreeMinutesPolicy
    {
        int CalculateFreeMinutes(double totalMinutes);
    }
}
