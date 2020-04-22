using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.ApplicationLayer.DTOs
{
    public enum OpenCloseDTO
    {
        Open,
        Closed
    }
    public class OfficeDTO
    {
        public string Director { get; protected set; }
        public AddressDTO Address { get; set; }
        public string OpenFrom { get; set; }
        public string OpenTo { get; set; }
        public OpenCloseDTO IsOpen { get; set; }
    }
}
