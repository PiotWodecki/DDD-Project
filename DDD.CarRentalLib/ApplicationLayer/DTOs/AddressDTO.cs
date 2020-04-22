using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.ApplicationLayer.DTOs
{
    public class AddressDTO
    {
        public string Locality { get; protected set; }
        public string Province { get; protected set; }
        public string Parish { get; protected set; }
        public string County { get; protected set; }
        private PostalCodeDTO PostalCode { get; set; }
    }
}
