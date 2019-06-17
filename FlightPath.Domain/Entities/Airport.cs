using System.Collections.Generic;

namespace FlightPath.Domain.Entities
{
    public class Airport
    {
        public Airport()
        {
            AirportFee = new HashSet<AirportFee>();
            AirportFuel = new HashSet<AirportFuel>();
            Radio = new HashSet<Radio>();
            Runway = new HashSet<Runway>();
        }

        public string AirportName { get; set; }
        public bool Icao { get; set; }
        public string Designator { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Elevation { get; set; }

        public ICollection<AirportFee> AirportFee { get; set; }
        public ICollection<AirportFuel> AirportFuel { get; set; }
        public ICollection<Radio> Radio { get; set; }
        public ICollection<Runway> Runway { get; set; }
    }
}
