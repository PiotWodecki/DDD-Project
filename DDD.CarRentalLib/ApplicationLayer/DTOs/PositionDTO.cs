using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.ApplicationLayer.DTOs
{
    public class PositionDTO
    {
        public double XPosition { get; set; }
        public double YPosition { get; set; }
        public DistanceUnitDTO Unit { get; set; }
    }
}
