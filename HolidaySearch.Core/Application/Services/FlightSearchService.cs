using HolidaySearch.Core.Domain.Request;
using HolidaySearch.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Core.Application.Services
{
    public class FlightSearchService
    {
        private readonly IEnumerable<Flight> _flights;

        public FlightSearchService(IEnumerable<Flight> flights)
        {
            _flights = flights;
        }

        public IEnumerable<Flight> Search(SearchRequest request)
        {
            return _flights.Where(f =>
                (request.DepartingFrom == null || !request.DepartingFrom.Any() || request.DepartingFrom.Contains(f.From)) &&
                f.To == request.TravelingTo &&
                f.DepartureDate.Date == request.DepartureDate.Date);
        }
    }
}
