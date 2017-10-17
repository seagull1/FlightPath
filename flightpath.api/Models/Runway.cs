using System;
using System.Collections.Generic;

namespace flightpath.api.Models
{
    public partial class Runway
    {
        public string AirportName { get; set; }
        public DateTime CreateDate { get; set; }
        public string RunwayNumber { get; set; }
        public int RunwayLength { get; set; }
        public int RunwayWidth { get; set; }
        public string RunwaySurface { get; set; }
        public string Designator { get; set; }
        public int Id { get; set; }

        public Airport DesignatorNavigation { get; set; }
    }
}
