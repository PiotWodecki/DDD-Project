using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.ApplicationLayer.DTOs
{
    public enum DistanceUnitDTO
    {
        Kilometers,
        Miles
    }
    public class DistanceDTO
    {
        public double Value { get; set; }
        public DistanceUnitDTO Unit { get; set; }
    }
}
