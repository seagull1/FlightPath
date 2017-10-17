using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flightpath.api.Utils
{
    public class Coordinate
    {
        private double _latitude;
        private double _longitude;

        public Coordinate(double latitude, double longitude)
        {
            _latitude = latitude;
            _longitude = longitude;
        }

        #region ISpatialCoordinate Members

        public double Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                _latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                _longitude = value;
            }
        }

        #endregion
    }
}
