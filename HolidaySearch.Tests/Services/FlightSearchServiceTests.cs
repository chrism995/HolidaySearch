using HolidaySearch.Core.Application.Services;
using HolidaySearch.Core.Domain;
using HolidaySearch.Core.Domain.Request;
using Moq;
using HolidaySearch.Core.Application.Interfaces.Repositories;

namespace HolidaySearch.Tests.Services
{
    public class FlightSearchServiceTests
    {
        private Mock<IFlightRepository> _mockFlightRepository;
        private FlightSearchService _flightSearchService;

        [SetUp]
        public void Setup()
        {
            // Create a mock repository
            _mockFlightRepository = new Mock<IFlightRepository>();

            // Set up mock data
            var mockFlights = new List<Flight>
            {
                new() { Id = 1, From = "MAN", To = "AGP", DepartureDate = new DateTime(2023, 7, 1), Price = 200 },
                new() { Id = 2, From = "LGW", To = "AGP", DepartureDate = new DateTime(2023, 7, 1), Price = 180 },
                new() { Id = 3, From = "LTN", To = "PMI", DepartureDate = new DateTime(2023, 6, 15), Price = 150 }
            };

            // Configure the mock to return the mock flights
            _mockFlightRepository.Setup(repo => repo.GetAllFlights()).Returns(mockFlights);

            // Inject the mock repository into the service
            _flightSearchService = new FlightSearchService(_mockFlightRepository.Object);
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