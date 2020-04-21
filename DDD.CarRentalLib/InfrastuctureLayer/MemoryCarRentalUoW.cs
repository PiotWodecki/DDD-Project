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
        public MemoryCarRentalUoW(IRepository<Driver> driverRepository, IRepository<Car> carRepository, IRepository<Rental> rentalRepository)
        {
            DriverRepository = driverRepository;
            CarRepository = carRepository;
            RentalRepository = rentalRepository;
        }

        public IRepository<Driver> DriverRepository { get; protected set; }
        public IRepository<Car> CarRepository { get; protected set; }
        public IRepository<Rental> RentalRepository { get; protected set; }

        public void Commit() { }
        public void Dispose() { }
        public void RejectChanges() { }
    }
}
