using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DDD.Base.DomainModelLayer.Events;
using DDD.CarRentalLib.ApplicationLayer.DTOs;
using DDD.CarRentalLib.ApplicationLayer.Interfaces;
using DDD.CarRentalLib.ApplicationLayer.Mappers;
using DDD.CarRentalLib.DomainModelLayer.Interfaces;
using DDD.CarRentalLib.DomainModelLayer.Models;
using DDD.CarRentalLib.InfrastuctureLayer;

namespace DDD.CarRentalLib.ApplicationLayer.Services
{
    public class CarService : ICarService
    {
        private ICarRentalUoW _uoW;
        private CarMapper _carMapper;
        private IDomainEventPublisher _domainEventPublisher;

        public CarService(ICarRentalUoW uoW, CarMapper carMapper, IDomainEventPublisher domainEventPublisher)
        {
            _uoW = uoW;
            _carMapper = carMapper;
            _domainEventPublisher = domainEventPublisher;
        }

        public void CreateCar(CarDTO carDTO)
        {
            Expression<Func<Car, bool>> expressionPredicate = c => c.RegistrationNumber == carDTO.RegistrationNumber;
            var car = this._uoW.CarRepository.Find(expressionPredicate).FirstOrDefault();
            if (car != null)
            {
                throw new Exception($"Car with this registration number: {carDTO.RegistrationNumber} already exists");
            }

            var totalDistance = new Distance(carDTO.TotalDistance.Value, (DistanceUnit) carDTO.TotalDistance.Unit);
            var currentDistance = new Distance(carDTO.CurrentDistance.Value, (DistanceUnit) carDTO.CurrentDistance.Unit);

            var position = new Position(carDTO.CurrentPosition.XPosition, carDTO.CurrentPosition.YPosition, (DistanceUnit) carDTO.CurrentPosition.Unit);

            car = new Car(
                carDTO.Id,
                carDTO.RegistrationNumber,
                (Status)carDTO.Status,
                position,
                currentDistance,
                totalDistance,
                _domainEventPublisher
            );

                this._uoW.CarRepository.Insert(car);
                this._uoW.Commit();
        }


        public List<CarDTO> GetAllCarsWithPosition()
        {
            IList<Car> cars = this._uoW.CarRepository.GetAll();
            List<CarDTO> dtoResult = this._carMapper.Map(cars);
            var positionService = new PositionService(this._domainEventPublisher, this._uoW);

            foreach (var car in dtoResult)
            {
                car.CurrentPosition = this._carMapper.Map(positionService.GetCarPosition(car.Id));
            }

            return dtoResult;
        }
    }
}
