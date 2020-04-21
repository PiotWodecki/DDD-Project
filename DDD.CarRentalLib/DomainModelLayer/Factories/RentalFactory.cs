using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.DomainModelLayer.Events;
using DDD.CarRentalLib.DomainModelLayer.Models;

namespace DDD.CarRentalLib.DomainModelLayer.Factories
{
    public class RentalFactory
    {
        private IDomainEventPublisher _domainEventPublisher;

        public RentalFactory(IDomainEventPublisher domainEventPublisher)
        {
            _domainEventPublisher = domainEventPublisher;
        }

        public Rental Create(Guid rentalId, Car car, Driver driver, DateTime startDate)
        {
            if (IsCarFree(car))
            {
                return new Rental(rentalId, startDate, car.Id, driver.Id, _domainEventPublisher);
            }
            else
            {
                throw new Exception("No free cars");
            }
        }

        private bool IsCarFree(Car car)
        {
            return car.Status == Status.Free;
        }
    }
}
