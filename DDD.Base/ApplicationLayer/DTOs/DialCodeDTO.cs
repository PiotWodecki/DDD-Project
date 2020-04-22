using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Base.ApplicationLayer.DTOs
{
    public class DialCodeDTO
    {
        public string Prefix { get; set; }
        public string Country { get; set; }
        public string Code { get; set; }
    }
}
