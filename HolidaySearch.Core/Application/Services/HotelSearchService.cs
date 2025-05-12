using HolidaySearch.Core.Domain.Request;
using HolidaySearch.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidaySearch.Core.Application.Interfaces;

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
