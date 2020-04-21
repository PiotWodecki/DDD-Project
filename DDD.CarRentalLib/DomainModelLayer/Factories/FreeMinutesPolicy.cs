using System;
using System.Collections.Generic;
using System.Text;
using DDD.CarRentalLib.DomainModelLayer.Interfaces;
using DDD.CarRentalLib.DomainModelLayer.Models;
using DDD.CarRentalLib.DomainModelLayer.Policies;

namespace DDD.CarRentalLib.DomainModelLayer.Factories
{
    public class FreeMinutesPolicy
    {
        public IFreeMinutesPolicy Create(Driver driver)
        {
            IFreeMinutesPolicy freeMinutesPolicy = new StandardPolicy();
            
            if (driver.LicenseNumber.Contains("Pracownik") || driver.LicenseNumber.Contains("Ratownik medyczny"))
            {
                freeMinutesPolicy = new PremiumPolicy();
            }
            
            return freeMinutesPolicy;
        }
    }
}
