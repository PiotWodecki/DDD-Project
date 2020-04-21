using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.ApplicationLayer.Services;
using DDD.CarRentalLib.ApplicationLayer.DTOs;

namespace DDD.CarRentalLib.ApplicationLayer.Interfaces
{
    public interface IDriverService : IApplicationService
    {
        void CreateDriver(DriverDTO driver);
        List<DriverDTO> GetAllDrivers();
    }
}
