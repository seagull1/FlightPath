using System;
using System.Collections.Generic;

namespace flightpath.api.Models
{
    public partial class AirportFuel
    {
        public string AirportName { get; set; }
        public DateTime CreateDate { get; set; }
        public string FuelType { get; set; }
        public decimal? FuelPrice { get; set; }
        public string FuelPriceComments { get; set; }
        public string FuelVenderName { get; set; }
        public string FuelVenderRadio { get; set; }
        public string FuelVenderPhone { get; set; }
        public string Designator { get; set; }
        public int Id { get; set; }

        public Airport DesignatorNavigation { get; set; }
    }
}
