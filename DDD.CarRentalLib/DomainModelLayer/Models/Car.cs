using DDD.Base.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using DDD.Base.DomainModelLayer.Events;

namespace DDD.CarRentalLib.DomainModelLayer.Models
{
    public enum Status
    {
        Free,
        Reserved,
        Rented
    }
    public class Car : AggregateRoot
    {
        public string RegistrationNumber { get; protected set; }
        public Status Status{ get; protected set; }
        public Position CurrentPosition { get; protected set; }
        public Distance CurrentDistance { get; protected set; }
        public Distance TotalDistance { get; protected set; }

        public Car(Guid id, string registrationNumber, Status status, Position currentPostion, Distance currentDistance, Distance totalDistance,
            IDomainEventPublisher domainEventPublisher) : base(id, domainEventPublisher)
        {
            RegistrationNumber = registrationNumber;
            Status = status;
            CurrentPosition = currentPostion;
            CurrentDistance = currentDistance;
            TotalDistance = totalDistance;
        }

        public void FreeCarFromReservation()
        {
            Status = Status.Free;
        }

        public void UpdateCarLocalization(Position position)
        {
            CurrentPosition = position;
        }

        public void Rent()
        {
            Status = Status.Rented;
        }
    }
}
