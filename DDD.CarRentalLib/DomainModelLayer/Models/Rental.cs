using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;

namespace DDD.CarRentalLib.DomainModelLayer.Models
{
    public class Rental : AggregateRoot
    {
        public DateTime Started { get; protected set; }
        public DateTime Finished { get; protected set; }
        public Guid CarId { get; protected set; }
        public Guid DriverId { get; protected set; }
        public Money TotalMoney { get; protected set; }
        
        public Rental(Guid id, DateTime started, DateTime finished, Guid carId, Guid driverId, Money totalMoney,
            IDomainEventPublisher domainEventPublisher) : base(id, domainEventPublisher)
        {
            Started = started;
            Finished = finished;
            CarId = carId;
            DriverId = driverId;
            TotalMoney = totalMoney;
        }

        public Rental(Guid id, DateTime started, Guid carId, Guid driverId,
            IDomainEventPublisher domainEventPublisher) : base(id, domainEventPublisher)
        {
            Started = started;
            CarId = carId;
            DriverId = driverId;
            Money startCalculateFee = new Money(0);
            TotalMoney = startCalculateFee;
        }

        public double StopCarRental(DateTime stopTime)
        {
            Finished = stopTime;

            var totalMinutes = (Started - Finished).TotalMinutes;

            return totalMinutes;
        }

        public double CalculateFee(double totalMinutes)
        {
            var totalPayment = (totalMinutes * 3) - totalMinutes / 10 * 3;

            TotalMoney = new Money((decimal)totalPayment, "zl");

            return totalPayment;
        }


    }
}
