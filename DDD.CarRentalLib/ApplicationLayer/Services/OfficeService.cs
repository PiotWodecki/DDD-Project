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
    public class OfficeService : IOfficeService
    {
        private ICarRentalUoW _uoW;
        private OfficeMapper _officeMapper;
        private IDomainEventPublisher _domainEventPublisher;

        public OfficeService(ICarRentalUoW uoW, OfficeMapper officeMapper, IDomainEventPublisher domainEventPublisher)
        {
            _uoW = uoW;
            _officeMapper = officeMapper;
            _domainEventPublisher = domainEventPublisher;
        }

        public void CreateNewOffice(OfficeDTO officeDTO)
        {
            Expression<Func<Office, bool>> expressionPredicate = o => o.Id == officeDTO.Id;
            var office = this._uoW.OfficeRepository.Find(expressionPredicate).FirstOrDefault();
            if (office != null)
            {
                throw new Exception("Office with this ID already exists");
            }

            var postalCode = new PostalCode(officeDTO.Address.PostalCode.FirstPart, officeDTO.Address.PostalCode.SecondPart);
            var dialCode = new DialCode(officeDTO.PhoneNumber.AreaCode.Prefix, officeDTO.PhoneNumber.AreaCode.Country, officeDTO.PhoneNumber.AreaCode.Code);

            var address = new Address(officeDTO.Address.Locality, officeDTO.Address.Province, officeDTO.Address.Parish,officeDTO.Address.County, postalCode,officeDTO.Address.Country, officeDTO.Address.Street,
                officeDTO.Address.BuildingNumber, officeDTO.Address.LocalNumber);
            var phoneNumber = new PhoneNumber(officeDTO.PhoneNumber.Number, dialCode);

            office = new Office(
                officeDTO.Id,
                officeDTO.Director,
                address,
                officeDTO.OpenFrom,
                officeDTO.OpenTo,
                (OpenClose) officeDTO.IsOpen,
                phoneNumber,
                _domainEventPublisher
                );

            _uoW.OfficeRepository.Insert(office);
            _uoW.Commit();

        }

        public List<OfficeDTO> GetAllOfficeAddress()
        {
            IList<Office> offices = _uoW.OfficeRepository.GetAll();
            List<OfficeDTO> dtoResults = _officeMapper.Map(offices);
            var addressService = new AddressService(_domainEventPublisher, _uoW);

            dtoResults.Select(o => o.Address = _officeMapper.Map(addressService.GetOfficeFullAddress(o.Id))).ToList();

            return dtoResults;
        }

        public List<OfficeDTO> GetAllOfficePhoneNumber()
        {
            IList<Office> offices = _uoW.OfficeRepository.GetAll();
            List<OfficeDTO> dtoResults = _officeMapper.Map(offices);
            var phoneNumberService = new PhoneNumberService(_domainEventPublisher, _uoW);

            dtoResults.Select(o => o.PhoneNumber = _officeMapper.Map(phoneNumberService.GetOfficeFullNumber(o.Id)));

            return dtoResults;
        }
    }
}
