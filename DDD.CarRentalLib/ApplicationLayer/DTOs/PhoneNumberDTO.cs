
using DDD.Base.ApplicationLayer.DTOs;

namespace DDD.CarRentalLib.ApplicationLayer.DTOs
{
    public class PhoneNumberDTO
    {
        public string Number { get;  set; }
        public DialCodeDTO AreaCode { get;  set; }
    }
}
