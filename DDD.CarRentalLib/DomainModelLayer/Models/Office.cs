using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;

namespace DDD.CarRentalLib.DomainModelLayer.Models
{
    public class Office : AggregateRoot
    {

        public Office(Guid id, IDomainEventPublisher domainEventPublisher) : base(id, domainEventPublisher)
        {
        }
    }
}
