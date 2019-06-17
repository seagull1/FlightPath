using System;

namespace FlightPath.Domain.Entities
{
    public class AirportFee
    {
        public string AirportName { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal? FeeLanding { get; set; }
        public decimal? FeeTerminal { get; set; }
        public decimal? FeeParking { get; set; }
        public decimal? FeeFuelTax { get; set; }
        public string FeeComments { get; set; }
        public string Designator { get; set; }
        public int Id { get; set; }

        public Airport DesignatorNavigation { get; set; }
    }
}
