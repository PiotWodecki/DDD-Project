using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.ApplicationLayer.DTOs;

namespace DDD.CarRentalLib.ApplicationLayer.DTOs
{
    public class RentalDTO
    {
        public Guid Id { get; set; }
        public DateTime Started { get; set; }
        public DateTime Finished { get; set; }
        public Guid DriverId { get; set; }
        public Guid CarId { get; set; }
        public MoneyDTO TotalMoney { get; set; }
    }
}
