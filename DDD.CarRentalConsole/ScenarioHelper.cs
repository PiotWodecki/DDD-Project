using DDD.CarRentalLib.ApplicationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DDD.CarRentalLib.ApplicationLayer.DTOs;
using DDD.CarRentalLib.DomainModelLayer.Services;

namespace DDD.CarRentalConsole
{
    public class ScenarioHelper
    {
        private IDriverService _driverService;
        private ICarService _carService;
        private IRentalService _rentalService;
        private StopRentalService _finishRentalService;

        public ScenarioHelper(IDriverService driverService, ICarService carService, IRentalService rentalService, StopRentalService finishRentalService)
        {
            _driverService = driverService;
            _carService = carService;
            _rentalService = rentalService;
            _finishRentalService = finishRentalService;
        }

        public Guid CreateDriver(string firstName, string lastName, string licenseNumber)
        {
            var driverId = Guid.NewGuid();
            var driverDto = new DriverDTO()
            {
                FirstName = firstName,
                FreeMinutes = 0,
                Id = driverId,
                LastName = lastName,
                LicenseNumber = licenseNumber
            };
            
            _driverService.CreateDriver(driverDto);

            return driverId;

        }

        public Guid CreateCar(string registration)
        {
            Guid carId = Guid.NewGuid();

            var startingPosition = new PositionDTO()
            {
                XPosition = 0,
                YPosition = 0,
                Unit = DistanceUnitDTO.Kilometers
            };

            var startingDistance = new DistanceDTO()
            {
                Unit = DistanceUnitDTO.Kilometers,
                Value = 0
            };

            var carDto = new CarDTO()
            {
                CurrentDistance = startingDistance,
                CurrentPosition = startingPosition,
                Id = carId,
                RegistrationNumber = registration,
                Status = CarStatusDTO.Free,
                TotalDistance = startingDistance
            };
            _carService.CreateCar(carDto);
            
            return carId;
        }

        public Guid StartRental(Guid driverId, Guid carId)
        {
            Guid rentalId = Guid.NewGuid();
            _rentalService.StartRental(rentalId, carId, driverId, DateTime.Now);

            return rentalId;

        }

        public void FinishRental(Guid rentalId, Guid carId, Guid driverId)
        {
            this._finishRentalService.FinishRental(rentalId, carId, driverId, DateTime.Now);
        }

        public void ShowDrivers()
        {
            List<DriverDTO> drivers = _driverService.GetAllDrivers();
            foreach (DriverDTO driver in drivers)
            {
                Console.WriteLine($"Driver name: {driver.FirstName} \n Driver surname: {driver.LastName} \n Driver licence: {driver.LicenseNumber} \n " +
                                  $"Minutes: {driver.FreeMinutes}");
                Console.WriteLine("##########################################");
            }

        }

        public void ShowCars()
        {
            List<CarDTO> cars = this._carService.GetAllCarsWithPosition();
            
            foreach (CarDTO car in cars)
            {
                Console.WriteLine($"Car registration number {car.RegistrationNumber} \n car status: {car.Status} \n" +
                                  $" (Car position: {car.CurrentPosition.XPosition}, {car.CurrentPosition.YPosition})");
                Console.WriteLine("##########################################");
            }
        }

        public void ShowRentals()
        {
            Console.WriteLine("********Rentals!*****");
            List<RentalDTO> rentals = this._rentalService.GetAllRentals();
            foreach (RentalDTO rental in rentals)
            {
                Console.WriteLine($"Rental no: {rental.Id} \n Car: {rental.CarId} \n Driver: {rental.DriverId} \n " +
                                  $"Start: {rental.Started} \n Finish: {rental.Finished}");
                Console.WriteLine("##########################################");
            }
        }
    }
}
