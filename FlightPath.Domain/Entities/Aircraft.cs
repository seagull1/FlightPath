using System;

namespace FlightPath.Domain.Entities
{
    public class Aircraft
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Horsepower { get; set; }
        public int? WeightEmpty { get; set; }
        public int FuelCapacity { get; set; }
        public int? WeightGross { get; set; }
        public int? SpeedTop { get; set; }
        public int SpeedCruise { get; set; }
        public int? SpeedStall { get; set; }
        public int Range { get; set; }
        public int? TakeoffGroundRoll { get; set; }
        public int? LandingGroundRoll { get; set; }
        public int? Takeoff50ftObst { get; set; }
        public int? Landing50ftObst { get; set; }
        public int? RateOfClimb { get; set; }
        public int? RateOfClimbSingle { get; set; }
        public int Ceiling { get; set; }
        public int? CeilingSingle { get; set; }
        public int? FuelBurn { get; set; }
        public int Id { get; set; }
    }
}
