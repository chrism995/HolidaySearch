using HolidaySearch.Core.Application.Interfaces;
using HolidaySearch.Core.Application.Interfaces.Repositories;
using HolidaySearch.Core.Domain;
using HolidaySearch.Core.Domain.Request;

namespace HolidaySearch.Core.Application.Services
{
    public class FlightSearchService: IFlightSearchService
    {
        private readonly IFlightRepository _flightRepository;

        public FlightSearchService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public IEnumerable<Flight> Search(SearchRequest request)
        {
            var flights = _flightRepository.GetAllFlights();

            return flights.Where(f =>
                (request.DepartingFrom == null || !request.DepartingFrom.Any() || request.DepartingFrom.Contains(f.From)) &&
                f.To == request.TravelingTo &&
                f.DepartureDate.Date == request.DepartureDate.Date);
        }
    }
}