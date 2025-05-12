using HolidaySearch.Core.Application.Services;
using HolidaySearch.Core.Domain;
using HolidaySearch.Core.Domain.Request;

namespace HolidaySearch.Tests.Services
{
    public class HotelSearchServiceTests
    {
        private HotelSearchService _hotelSearchService;
        private List<Hotel> _mockHotels;

        [SetUp]
        public void Setup()
        {
            _mockHotels = new List<Hotel>
            {
                new()
                {
                    Id = 1,
                    Name = "Nh Malaga",
                    ArrivalDate = new DateTime(2023, 7, 1),
                    Nights = 7,
                    PricePerNight = 90,
                    LocalAirports = new List<string> { "AGP" }
                },
                new()
                {
                    Id = 2,
                    Name = "Hotel Mallorca",
                    ArrivalDate = new DateTime(2023, 6, 15),
                    Nights = 10,
                    PricePerNight = 100,
                    LocalAirports = new List<string> { "PMI" }
                },
                new()
                {
                    Id = 3,
                    Name = "Invalid Date",
                    ArrivalDate = new DateTime(2023, 6, 14),
                    Nights = 7,
                    PricePerNight = 80,
                    LocalAirports = new List<string> { "AGP" }
                }
            };

            _hotelSearchService = new HotelSearchService(_mockHotels);
        }

        [Test]
        public void ReturnsHotelsMatchingArrivalDateAirportAndDuration()
        {
            var request = new SearchRequest
            {
                DepartureDate = new DateTime(2023, 7, 1),
                TravelingTo = "AGP",
                Duration = 7
            };

            var results = _hotelSearchService.Search(request).ToList();

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(1, results.First().Id);
        }

        [Test]
        public void ReturnsNoHotels_WhenNoMatchOnDate()
        {
            var request = new SearchRequest
            {
                DepartureDate = new DateTime(2023, 7, 2),
                TravelingTo = "AGP",
                Duration = 7
            };

            var results = _hotelSearchService.Search(request).ToList();

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ReturnsNoHotels_WhenNoMatchOnAirport()
        {
            var request = new SearchRequest
            {
                DepartureDate = new DateTime(2023, 6, 15),
                TravelingTo = "LPA",
                Duration = 10
            };

            var results = _hotelSearchService.Search(request).ToList();

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ReturnsNoHotels_WhenNoMatchOnDuration()
        {
            var request = new SearchRequest
            {
                DepartureDate = new DateTime(2023, 6, 15),
                TravelingTo = "PMI",
                Duration = 7 
            };

            var results = _hotelSearchService.Search(request).ToList();

            Assert.AreEqual(0, results.Count);
        }
    }
}
