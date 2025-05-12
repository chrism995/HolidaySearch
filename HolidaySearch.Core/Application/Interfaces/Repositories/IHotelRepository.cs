using HolidaySearch.Core.Domain;

namespace HolidaySearch.Core.Application.Interfaces.Repositories
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> GetAllHotels();
    }
}