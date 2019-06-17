using System;
using System.Linq.Expressions;
using FlightPath.Domain.Entities;

namespace FlightPath.Application.Aircrafts.Queries
{
    public class AircraftDetailModel
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int FuelCapacity { get; set; }
        public int SpeedCruise { get; set; }
        public int Range { get; set; }
        public int Ceiling { get; set; }
        public int? Horsepower { get; set; }
        public int? WeightEmpty { get; set; }
        public int? WeightGross { get; set; }
        public int? SpeedTop { get; set; }
        public int? SpeedStall { get; set; }
        public int? TakeoffGroundRoll { get; set; }
        public int? LandingGroundRoll { get; set; }
        public int? Takeoff50ftObst { get; set; }
        public int? Landing50ftObst { get; set; }
        public int? RateOfClimb { get; set; }
        public int? RateOfClimbSingle { get; set; }
        public int? CeilingSingle { get; set; }
        public int? FuelBurn { get; set; }

        public static Expression<Func<Aircraft, AircraftDetailModel>> Projection
        {
            get
            {
                return aircraft => new AircraftDetailModel
                {
                    Id = aircraft.Id,
                    Make = aircraft.Make,
                    Model = aircraft.Model,
                    FuelCapacity = aircraft.FuelCapacity,
                    SpeedCruise = aircraft.SpeedCruise,
                    Range = aircraft.Range,
                    Ceiling = aircraft.Ceiling,
                    Horsepower = aircraft.Horsepower,
                    WeightEmpty = aircraft.WeightEmpty,
                    WeightGross = aircraft.WeightGross,
                    SpeedTop = aircraft.SpeedTop,
                    SpeedStall = aircraft.SpeedStall,
                    TakeoffGroundRoll = aircraft.TakeoffGroundRoll,
                    LandingGroundRoll = aircraft.LandingGroundRoll,
                    Takeoff50ftObst = aircraft.Takeoff50ftObst,
                    Landing50ftObst = aircraft.Landing50ftObst,
                    RateOfClimb = aircraft.RateOfClimb,
                    RateOfClimbSingle = aircraft.RateOfClimbSingle,
                    CeilingSingle = aircraft.WeightGross,
                    FuelBurn = aircraft.FuelBurn
                };
            }
        }

        public static AircraftDetailModel Create(Aircraft aircraft)
        {
            return Projection.Compile().Invoke(aircraft);
        }
    }
}
