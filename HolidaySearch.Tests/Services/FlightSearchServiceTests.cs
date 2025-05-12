using HolidaySearch.Core.Application.Services;
using HolidaySearch.Core.Domain;
using HolidaySearch.Core.Domain.Request;

namespace HolidaySearch.Tests.Services
{
    public class FlightSearchServiceTests
    {
        private FlightSearchService _flightSearchService;
        private List<Flight> _mockFlights;

        [SetUp]
        public void Setup()
        {
            _mockFlights = new List<Flight>
            {
                new() { Id = 1, From = "MAN", To = "AGP", DepartureDate = new DateTime(2023, 7, 1), Price = 200 },
                new() { Id = 2, From = "LGW", To = "AGP", DepartureDate = new DateTime(2023, 7, 1), Price = 180 },
                new() { Id = 3, From = "LTN", To = "PMI", DepartureDate = new DateTime(2023, 6, 15), Price = 150 }
            };

            _flightSearchService = new FlightSearchService(_mockFlights);
        }

        [Test]
        public void ReturnsFlightsMatchingSingleDepartureAirport()
        {
            var request = new SearchRequest
            {
                DepartingFrom = new List<string> { "MAN" },
                TravelingTo = "AGP",
                DepartureDate = new DateTime(2023, 7, 1),
                Duration = 7
            };

            var results = _flightSearchService.Search(request).ToList();

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(1, results.First().Id);
        }

        [Test]
        public void ReturnsFlightsMatchingMultipleDepartureAirports()
        {
            var request = new SearchRequest
            {
                DepartingFrom = new List<string> { "MAN", "LGW" },
                TravelingTo = "AGP",
                DepartureDate = new DateTime(2023, 7, 1),
                Duration = 7
            };

            var results = _flightSearchService.Search(request).ToList();

            Assert.AreEqual(2, results.Count);
        }

        [Test]
        public void ReturnsNoFlightsIfNoneMatch()
        {
            var request = new SearchRequest
            {
                DepartingFrom = new List<string> { "MAN" },
                TravelingTo = "PMI",
                DepartureDate = new DateTime(2023, 8, 1),
                Duration = 7
            };

            var results = _flightSearchService.Search(request).ToList();

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ReturnsAllFromAvailableFlightsIfDepartingFromIsEmpty()
        {
            var request = new SearchRequest
            {
                DepartingFrom = new List<string>(),
                TravelingTo = "AGP",
                DepartureDate = new DateTime(2023, 7, 1),
                Duration = 7
            };

            var results = _flightSearchService.Search(request).ToList();

            Assert.AreEqual(2, results.Count);
        }
    }
}
