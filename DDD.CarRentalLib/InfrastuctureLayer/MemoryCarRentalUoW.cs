using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.DomainModelLayer.Interfaces;
using DDD.CarRentalLib.DomainModelLayer.Interfaces;
using DDD.CarRentalLib.DomainModelLayer.Models;

namespace DDD.CarRentalLib.InfrastuctureLayer
{
    public class MemoryCarRentalUoW : ICarRentalUoW
    {
        public IRepository<Driver> DriverRepository { get; protected set; }
        public IRepository<Car> CarRepository { get; protected set; }
        public IRepository<Rental> RentalRepository { get; protected set; }
        public IRepository<Office> OfficeRepository { get; }
        
        public MemoryCarRentalUoW(IRepository<Driver> driverRepository, IRepository<Car> carRepository, IRepository<Rental> rentalRepository, IRepository<Office> officeRepository)
        {
            DriverRepository = driverRepository;
            CarRepository = carRepository;
            RentalRepository = rentalRepository;
            OfficeRepository = officeRepository;
        }

        public void Commit() { }
        public void Dispose() { }
        public void RejectChanges() { }
    }
}
