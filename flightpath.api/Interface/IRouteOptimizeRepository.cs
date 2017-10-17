using flightpath.api.Models;
using flightpath.api.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace flightpath.api.Interface
{
    public interface IRouteOptimizeRepository
    {
        IEnumerable<AirportDto> OptimizeRoute(SearchCriteria criteris);
    }
}
