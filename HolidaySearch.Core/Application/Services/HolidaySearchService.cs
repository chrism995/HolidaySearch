using HolidaySearch.Core.Application.Interfaces;
using HolidaySearch.Core.Application.Services.Sorting;
using HolidaySearch.Core.Domain;
using HolidaySearch.Core.Domain.Enums;
using HolidaySearch.Core.Domain.Request;


namespace HolidaySearch.Core.Application.Services
{
    public class HolidaySearchService : IHolidaySearchService
    {
        private readonly IFlightSearchService _flightSearchService;
        private readonly IHotelSearchService _hotelSearchService;
        private readonly IHolidayMatchingService _holidayMatchingService;

        public HolidaySearchService(
            IFlightSearchService flightSearchService,
            IHotelSearchService hotelSearchService,
            IHolidayMatchingService holidayMatchingService)
            
        {
            _flightSearchService = flightSearchService;
            _hotelSearchService = hotelSearchService;
            _holidayMatchingService = holidayMatchingService;
        }

        public IEnumerable<Holiday> SearchHolidays(SearchRequest request, HolidaySortType sortType)
        {
            var flights = _flightSearchService.Search(request);
            var hotels = _hotelSearchService.Search(request);

            var matchingHolidays = _holidayMatchingService.MatchHolidays(flights, hotels, request);

            var sortingStrategy = HolidaySortFactory.Create(sortType);

            return sortingStrategy.Sort(matchingHolidays);
        }
    }
}
