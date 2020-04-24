using DDD.CarRentalLib.ApplicationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DDD.Base.ApplicationLayer.DTOs;
using DDD.CarRentalLib.ApplicationLayer.DTOs;
using DDD.CarRentalLib.DomainModelLayer.Models;
using DDD.CarRentalLib.DomainModelLayer.Services;

namespace DDD.CarRentalConsole
{
    public class ScenarioHelper
    {
        private IDriverService _driverService;
        private ICarService _carService;
        private IRentalService _rentalService;
        private IOfficeService _officeService;
        private StopRentalService _finishRentalService;

        public ScenarioHelper(IDriverService driverService, ICarService carService, IRentalService rentalService, IOfficeService officeService, StopRentalService finishRentalService)
        {
            _driverService = driverService;
            _carService = carService;
            _rentalService = rentalService;
            _finishRentalService = finishRentalService;
            _officeService = officeService;
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

        public Guid CreateOffice(string director, string openFrom, string openTo)
        {
            var officeId = Guid.NewGuid();

            var postalCode = new PostalCodeDTO()
            {
                FirstPart = "30",
                SecondPart = "002"
            };

            var address = new AddressDTO
            {
                PostalCode = postalCode,
                Country = "Poland",
                County = "krakowski",
                Locality = "Kraków",
                Street = "Jana Pawła II",
                Province = "małopolskie",
                Parish = "Kraków",
                LocalNumber = "2",
                BuildingNumber = "1"
            };

            var dialCode = new DialCodeDTO
            {
                Code = "PL",
                Country = "Poland",
                Prefix = "+48"
            };

            var phoneNumber = new PhoneNumberDTO
            {
                AreaCode = dialCode,
                Number = "322655766"
            };

            var office = new OfficeDTO
            {
                Id = officeId,
                PhoneNumber = phoneNumber,
                OpenFrom = openFrom,
                OpenTo = openTo,
                IsOpen = OpenCloseDTO.Open,
                Address = address,
                Director = director
            };

            _officeService.CreateNewOffice(office);

            return officeId;
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
            List<RentalDTO> rentals = this._rentalService.GetAllRentals();
            foreach (RentalDTO rental in rentals)
            {
                Console.WriteLine($"Rental no: {rental.Id} \n Car: {rental.CarId} \n Driver: {rental.DriverId} \n " +
                                  $"Start: {rental.Started} \n Finish: {rental.Finished}");
                Console.WriteLine("##########################################");
            }
        }

        public void ShowOfficesAddresses()
        {
            Console.WriteLine("OFFICES Addresses");

            List<OfficeDTO> offices = _officeService.GetAllOfficeAddress();
            foreach (var office in offices)
            {
                Console.WriteLine($"Office Director: {office.Director} \n Address:\n" +
                                  $"Postal code: {office.Address.PostalCode.FirstPart}-{office.Address.PostalCode.SecondPart}\n" +
                                  $"Country: {office.Address.Country}\n" +
                                  $"County: {office.Address.County}\n" +
                                  $"Parish: {office.Address.Parish}\n" +
                                  $"Province: {office.Address.Province}\n" +
                                  $"Locality: {office.Address.Locality}\n" +
                                  $"Street: {office.Address.Street}\n" +
                                  $"Building number: {office.Address.BuildingNumber}\n" +
                                  $"Local number: {office.Address.LocalNumber}");
                Console.WriteLine("##########################################");
            }
        }

        public void ShowOfficesPhoneNumbers()
        {
            Console.WriteLine("OFFICES phone numbers");

            List<OfficeDTO> offices = _officeService.GetAllOfficePhoneNumber();
            foreach (var office in offices)
            {
                Console.WriteLine($"Office Director: {office.Director} \nPhoneNumber:{office.PhoneNumber.AreaCode.Prefix} {office.PhoneNumber.Number}\n" +
                                  $"{office.PhoneNumber.AreaCode.Code}, {office.PhoneNumber.AreaCode.Country}");
                Console.WriteLine("##########################################");
            }
        } 
    }
}
