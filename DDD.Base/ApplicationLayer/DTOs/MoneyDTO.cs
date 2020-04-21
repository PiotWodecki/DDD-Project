using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Base.ApplicationLayer.DTOs
{
    public class MoneyDTO
    {
        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
