using HolidaySearch.Core.Domain;

namespace HolidaySearch.Core.Application.Interfaces.Repositories
{
    public interface IFlightRepository
    {
        IEnumerable<Flight> GetAllFlights();
    }
}
