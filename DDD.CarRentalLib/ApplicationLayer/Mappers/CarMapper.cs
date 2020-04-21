using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.CarRentalLib.ApplicationLayer.DTOs;
using DDD.CarRentalLib.DomainModelLayer.Models;

namespace DDD.CarRentalLib.ApplicationLayer.Mappers
{
    public class CarMapper
    {
        public List<CarDTO> Map(IEnumerable<Car> cars)
        {
            return cars.Select(c => Map(c)).ToList();
        }

        public CarDTO Map(Car car)
        {
            return new CarDTO
            {
                Id = car.Id,
                CurrentDistance = Map(car.CurrentDistance),
                TotalDistance = Map(car.TotalDistance),
                CurrentPosition = Map(car.CurrentPosition),
                RegistrationNumber = car.RegistrationNumber,
                Status = (CarStatusDTO) car.Status
            };
        }

        public PositionDTO Map(Position p)
        {
            return new PositionDTO
            {
                Unit = (DistanceUnitDTO)p.Distanceunit,
                XPosition = p.XPosition,
                YPosition = p.YPosition
            };
        }

        public DistanceDTO Map(Distance d)
        {
            return new DistanceDTO
            {
                Unit = (DistanceUnitDTO)d.Unit,
                Value = d.Value
            };
        }
    }
}
