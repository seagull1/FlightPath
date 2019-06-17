using System;
using System.Collections.Generic;
using System.Text;

namespace FlightPath.Domain.Entities
{
    public class Radio
    {
        public string AirportName { get; set; }
        public int? RadioId { get; set; }
        public string RadioName { get; set; }
        public string RadioFrequency { get; set; }
        public string Designator { get; set; }
        public int Id { get; set; }

        public Airport DesignatorNavigation { get; set; }
    }
}
