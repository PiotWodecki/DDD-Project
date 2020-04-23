using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.ApplicationLayer.DTOs
{
    public class AddressDTO
    {
        public string Locality { get; set; }
        public string Province { get; set; }
        public string Parish { get; set; }
        public string County { get; set; }
        public PostalCodeDTO PostalCode { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string LocalNumber { get; set; }
        public string Country { get; set; }
    }
}
