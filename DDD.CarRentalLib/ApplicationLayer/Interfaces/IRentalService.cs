using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.ApplicationLayer.Services;
using DDD.CarRentalLib.ApplicationLayer.DTOs;

namespace DDD.CarRentalLib.ApplicationLayer.Interfaces
{
    public interface IRentalService : IApplicationService
    {
        void StartRental(Guid rentalId, Guid carId, Guid driverId, DateTime starTime);
        List<RentalDTO> GetAllRentals();
    }
}
