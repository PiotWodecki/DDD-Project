using System;
using DDD.Base.DomainModelLayer.Events;
using DDD.Base.InfrastructureLayer.Services;
using DDD.CarRentalLib.DomainModelLayer.Interfaces;
using DDD.CarRentalLib.DomainModelLayer.Models;

namespace DDD.CarRentalLib.InfrastuctureLayer
{
    public class AddressService : IInfrastructureService
    {
        private IDomainEventPublisher _domainEventPublisher;
        private ICarRentalUoW _uoW;

        public AddressService(IDomainEventPublisher domainEventPublisher, ICarRentalUoW uoW)
        {
            _domainEventPublisher = domainEventPublisher;
            _uoW = uoW;
        }

        public Address GetOfficeFullAddress(Guid officeId)
        {
            var office = _uoW.OfficeRepository.Get(officeId);
            if (office == null)
            {
                throw new Exception("This office does not exist");
            }

            var country = "Poland";
            var buildingNumber = "1";
            var localNumber = "1";
            var postalCodeKrakow1 = "30-002";
            var postalCode = new PostalCode(postalCodeKrakow1.Split('-')[0], postalCodeKrakow1.Split('-')[1]);

            var addresstmp = new Address();
            var tmplist =addresstmp.GetAddressesByPostalCode(postalCode);

            var random =new Random();

            //losowy adres z tych podanych przez kod pocztowy - chodzi tu o to żeby była jakaś jedna ulica
            addresstmp = tmplist[random.Next(tmplist.Count - 1)];

            var address = new Address(addresstmp.Locality, addresstmp.Province, addresstmp.Parish,
                addresstmp.County, addresstmp.PostalCode, country, addresstmp.Street,
                buildingNumber, localNumber);
            
            
            return address;
        }
    }
}
