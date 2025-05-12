
using HolidaySearch.Core.Domain;

namespace HolidaySearch.Core.Application.Interfaces
{
    public interface IFlightRepository
    {
        IEnumerable<Flight> GetAllFlights();
    }
}
