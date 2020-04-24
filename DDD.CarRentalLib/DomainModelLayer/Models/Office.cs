using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;

namespace DDD.CarRentalLib.DomainModelLayer.Models
{
    public enum OpenClose
    {
        Open,
        Closed
    }
    public class Office : AggregateRoot
    {
        public string Director { get; protected set; }
        public Address Address { get; set; }
        public string OpenFrom { get; set; }
        public string OpenTo { get; set; }
        public OpenClose IsOpen { get; set; }
        public PhoneNumber PhoneNumber { get; set; }

        public Office(Guid id, string director, Address address, string openFrom, string openTo, OpenClose isOpen, PhoneNumber phoneNumber,
            IDomainEventPublisher domainEventPublisher) : base(id, domainEventPublisher)
        {
            Director = director;
            Address = address;
            OpenFrom = openFrom;
            OpenTo = openTo;
            IsOpen = isOpen;
            PhoneNumber = phoneNumber;
        }
    }
}
