using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Text;
using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;
using DDD.CarRentalLib.DomainModelLayer.Interfaces;

namespace DDD.CarRentalLib.DomainModelLayer.Models
{
    public class Driver : AggregateRoot
    {
        public string LicenseNumber { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public int FreeMinutes { get; protected set; }
        private IFreeMinutesPolicy _freeMinutesPolicy;
        public Driver(Guid id, string licenseNumber, string firstName, string lastName, int freeMinutes,
            IDomainEventPublisher domainEventPublisher) : base(id, domainEventPublisher)
        {
            LicenseNumber = licenseNumber;
            FirstName = firstName;
            LastName = lastName;
            FreeMinutes = freeMinutes;
        }

        public void RegisterPolicy(IFreeMinutesPolicy policy)
        {
            _freeMinutesPolicy = policy;
        }

        public void UpdateFreeMinutes(double inUseMinutes)
        {
            FreeMinutes += _freeMinutesPolicy.CalculateFreeMinutes(inUseMinutes);
        }
    }
}
