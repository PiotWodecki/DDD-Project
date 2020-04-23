using System.Collections.Generic;
using DDD.Base.ApplicationLayer.Services;
using DDD.CarRentalLib.ApplicationLayer.DTOs;
using DDD.CarRentalLib.DomainModelLayer.Models;

namespace DDD.CarRentalLib.ApplicationLayer.Interfaces
{
    public interface IOfficeService : IApplicationService
    {
        List<OfficeDTO> GetAllOfficeAddress();
        public List<OfficeDTO> GetAllOfficePhoneNumber();
        void CreateNewOffice(OfficeDTO officeDto);
    }
}
