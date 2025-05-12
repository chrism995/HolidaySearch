using HolidaySearch.Core.Domain;

namespace HolidaySearch.Core.Application.Interfaces
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> GetAllHotels();
    }
}