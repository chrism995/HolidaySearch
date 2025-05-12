using HolidaySearch.Core.Application.Services;
using HolidaySearch.Core.Domain;
using HolidaySearch.Core.Domain.Request;
using Moq;
using HolidaySearch.Core.Application.Interfaces.Repositories;

namespace HolidaySearch.Tests.Services
{
    public class HotelSearchServiceTests
    {
        private Mock<IHotelRepository> _mockHotelRepository;
        private HotelSearchService _hotelSearchService;

        [SetUp]
        public void Setup()
        {
            _mockHotelRepository = new Mock<IHotelRepository>();

            var mockHotels = new List<Hotel>
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

             _mockHotelRepository.Setup(repo => repo.GetAllHotels()).Returns(mockHotels);

            _hotelSearchService = new HotelSearchService(_mockHotelRepository.Object);
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
        public void ReturnsNoHotelsWhenNoMatchOnDate()
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
        public void ReturnsNoHotelsWhenNoMatchOnAirport()
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
        public void ReturnsNoHotelsWhenNoMatchOnDuration()
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