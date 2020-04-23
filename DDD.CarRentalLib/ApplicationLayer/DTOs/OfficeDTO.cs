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
        public Guid Id { get; set; }
        public string Director { get; set; }
        public AddressDTO Address { get; set; }
        public string OpenFrom { get; set; }
        public string OpenTo { get; set; }
        public OpenCloseDTO IsOpen { get; set; }
        public PhoneNumberDTO PhoneNumber { get; set; }
    }
}
