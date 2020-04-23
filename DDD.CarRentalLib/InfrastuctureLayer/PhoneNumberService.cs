using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.DomainModelLayer.Events;
using DDD.Base.InfrastructureLayer.Services;
using DDD.CarRentalLib.DomainModelLayer.Interfaces;
using DDD.CarRentalLib.DomainModelLayer.Models;

namespace DDD.CarRentalLib.InfrastuctureLayer
{
    public class PhoneNumberService : IInfrastructureService
    {
        private IDomainEventPublisher _domainEventPublisher;
        private ICarRentalUoW _uoW;

        public PhoneNumberService(IDomainEventPublisher domainEventPublisher, ICarRentalUoW uoW)
        {
            _domainEventPublisher = domainEventPublisher;
            _uoW = uoW;
        }

        public PhoneNumber GetOfficeFullNumber(Guid officeId)
        {
            Office office = _uoW.OfficeRepository.Get(officeId);
            if (office == null)
            {
                throw new Exception("This office does not exist");
            }

            Random random = new Random();

            var dialCode = DialCodeService.GetDialCodeByCountry(office.Address.Country);
            var phoneNum = random.Next(100000000, 999999999).ToString();
            var phoneNumber = new PhoneNumber(phoneNum, dialCode);

            return phoneNumber;
        }
    }
}
