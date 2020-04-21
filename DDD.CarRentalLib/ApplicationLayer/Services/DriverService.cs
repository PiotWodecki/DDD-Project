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

namespace DDD.CarRentalLib.ApplicationLayer.Services
{
    public class DriverService : IDriverService
    {
        private ICarRentalUoW _uoW;
        private DriverMapper _driverMapper;
        private IDomainEventPublisher _domainEventPublisher;

        public DriverService(ICarRentalUoW uoW, DriverMapper driverMapper, IDomainEventPublisher domainEventPublisher)
        {
            _uoW = uoW;
            _driverMapper = driverMapper;
            _domainEventPublisher = domainEventPublisher;
        }

        public void CreateDriver(DriverDTO driverDTO)
        {
            Expression<Func<Driver, bool>> expressionPredicate = d => d.LicenseNumber == driverDTO.LicenseNumber;
            var driver = this._uoW.DriverRepository.Find(expressionPredicate).FirstOrDefault();
            if (driver != null)
            {
                throw new Exception($"Driver with this license number: {driverDTO.LicenseNumber} already exists");
            }

            driver = new Driver(
                driverDTO.Id,
                driverDTO.LicenseNumber,
                driverDTO.FirstName,
                driverDTO.LastName,
                driverDTO.FreeMinutes,
                _domainEventPublisher);

            this._uoW.DriverRepository.Insert(driver);
            this._uoW.Commit();
        }

        public List<DriverDTO> GetAllDrivers()
        {
            IList<Driver> drivers = this._uoW.DriverRepository.GetAll();

            List<DriverDTO> dtoResult = this._driverMapper.Map(drivers);

            return dtoResult;

        }
    }
}
