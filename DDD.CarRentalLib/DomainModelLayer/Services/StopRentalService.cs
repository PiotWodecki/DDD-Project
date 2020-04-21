using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.DomainModelLayer.Events;
using DDD.CarRentalLib.DomainModelLayer.Interfaces;
using DDD.CarRentalLib.DomainModelLayer.Models;
using DDD.CarRentalLib.InfrastuctureLayer;

namespace DDD.CarRentalLib.DomainModelLayer.Services
{
    public class StopRentalService
    {
        private ICarRentalUoW _uoW;
        private IDomainEventPublisher _domainEventPublisher;

        private PositionService _positionService;

        public StopRentalService(ICarRentalUoW uoW, IDomainEventPublisher domainEventPublisher)
        {
            _uoW = uoW;
            _domainEventPublisher = domainEventPublisher;
            _positionService = new PositionService(domainEventPublisher, uoW);
        }

        public void FinishRental(Guid rentalId, Guid carId, Guid driverId, DateTime endTime)
        {
            Rental rental = this._uoW.RentalRepository.Get(rentalId);
            Driver driver = this._uoW.DriverRepository.Get(driverId);
            Car car = this._uoW.CarRepository.Get(carId);

            if (rental == null || driver == null || car == null)
            {
                throw new Exception("Something gone wrong");
            }

            car.FreeCarFromReservation();
            Position endCarPositionPosition = this._positionService.GetCarPosition(carId);
            car.UpdateCarLocalization(endCarPositionPosition);

            var inUseMinutes = rental.StopCarRental(endTime);

            driver.UpdateFreeMinutes(inUseMinutes);

            this._uoW.Commit();

        }
    }
}
