using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.Base.ApplicationLayer.DTOs;
using DDD.CarRentalLib.ApplicationLayer.DTOs;
using DDD.CarRentalLib.DomainModelLayer.Models;

namespace DDD.CarRentalLib.ApplicationLayer.Mappers
{
    public class OfficeMapper
    {
        public List<OfficeDTO> Map(IEnumerable<Office> offices)
        {
            return offices.Select(o => Map(o)).ToList();
        }

        public OfficeDTO Map(Office office)
        {
            return new OfficeDTO
            {
                Id = office.Id,
                OpenFrom = office.OpenFrom,
                OpenTo = office.OpenTo,
                IsOpen = (OpenCloseDTO)office.IsOpen,
                Address = Map(office.Address),
                Director = office.Director,
                PhoneNumber = Map(office.PhoneNumber),
            };
        }

        public AddressDTO Map(Address address)
        {
            return new AddressDTO
            {
                Country = address.Country,
                County = address.County,
                Locality = address.Locality,
                Province = address.Province,
                Parish = address.Parish,
                PostalCode = Map(address.PostalCode),
                Street = address.Street,
                LocalNumber = address.LocalNumber,
                BuildingNumber = address.BuildingNumber
            };
        }

        public PostalCodeDTO Map(PostalCode postalCode)
        {
            return new PostalCodeDTO
            {
                FirstPart = postalCode.FirstPart,
                SecondPart = postalCode.SecondPart
            };
        }

        public PhoneNumberDTO Map(PhoneNumber phoneNumber)
        {
            return new PhoneNumberDTO
            {
                AreaCode = Map(phoneNumber.AreaCode),
                Number = phoneNumber.Number
            };
        }

        public DialCodeDTO Map(DialCode dialCode)
        {
            return new DialCodeDTO
            {
                Code = dialCode.Code,
                Prefix = dialCode.Prefix,
                Country = dialCode.Country
            };
        }
    }
}
