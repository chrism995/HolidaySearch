using HolidaySearch.Core.Domain.Request;
using HolidaySearch.Core.Domain;
using HolidaySearch.Core.Application.Interfaces;
using HolidaySearch.Core.Application.Interfaces.Repositories;

namespace HolidaySearch.Core.Application.Services
{
    public class HotelSearchService: IHotelSearchService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelSearchService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public IEnumerable<Hotel> Search(SearchRequest request)
        {
            var hotels = _hotelRepository.GetAllHotels();

            return hotels.Where(h =>
                h.LocalAirports.Contains(request.TravelingTo) &&
                h.ArrivalDate.Date == request.DepartureDate.Date &&
                h.Nights == request.Duration);
        }
    }
}
