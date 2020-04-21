using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.Base.ApplicationLayer.DTOs;
using DDD.Base.DomainModelLayer.Models;
using DDD.CarRentalLib.ApplicationLayer.DTOs;
using DDD.CarRentalLib.DomainModelLayer.Models;

namespace DDD.CarRentalLib.ApplicationLayer.Mappers
{
    public class RentalMapper
    {
        public List<RentalDTO> Map(IEnumerable<Rental> rentals)
        {
            return rentals.Select(r => Map(r)).ToList();
        }

        public RentalDTO Map(Rental rental)
        {
            return new RentalDTO
            {
                Id = rental.Id,
                Finished = rental.Finished,
                Started = rental.Started,
                DriverId = rental.DriverId,
                CarId = rental.CarId,
                TotalMoney = Map(rental.TotalMoney)
            };
        }

        private MoneyDTO Map(Money money)
        {
            return new MoneyDTO
            {
                Amount = money.Amount,
                Currency = money.Currency
            };
        }
    }
}
