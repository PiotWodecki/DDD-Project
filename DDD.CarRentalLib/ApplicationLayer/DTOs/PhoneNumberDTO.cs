using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.ApplicationLayer.DTOs;

namespace DDD.CarRentalLib.ApplicationLayer.DTOs
{
    public class PhoneNumberDTO
    {
        public string Number { get; private set; }
        public DialCodeDTO AreaCode { get; private set; }
    }
}
