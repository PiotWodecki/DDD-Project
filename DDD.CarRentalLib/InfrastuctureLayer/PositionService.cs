using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.DomainModelLayer.Events;
using DDD.CarRentalLib.DomainModelLayer.Interfaces;
using DDD.CarRentalLib.DomainModelLayer.Models;

namespace DDD.CarRentalLib.InfrastuctureLayer
{
    public class PositionService
    {
        private IDomainEventPublisher _domainEventPublisher;
        private ICarRentalUoW _uoW;

        public PositionService(IDomainEventPublisher domainEventPublisher, ICarRentalUoW uoW)
        {
            _domainEventPublisher = domainEventPublisher;
            _uoW = uoW;
        }

        public Position GetCarPosition(Guid carId)
        {
            Car car = this._uoW.CarRepository.Get(carId);
            if (car == null)
            {
                throw new Exception("This car does not exist!");
            }

            Random rand = new Random();

            double xPos = rand.Next() * 100;
            double yPos = rand.Next() * 100;

            return new Position(xPos, yPos, DistanceUnit.Kilometers);
        }
    }
}
