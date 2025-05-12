using NUnit.Framework;
using Moq;
using HolidaySearch.Core.Application.Interfaces;
using HolidaySearch.Core.Domain;
using HolidaySearch.Core.Domain.Request;
using HolidaySearch.Core.Application.Services;
using HolidaySearch.Core.Domain.Enums;

namespace HolidaySearch.Tests
{
    [TestFixture]
    public class HolidaySearchServiceTests
    {
        private Mock<IFlightSearchService> _mockFlightSearchService;
        private Mock<IHotelSearchService> _mockHotelSearchService;
        private Mock<IHolidayMatchingService> _mockHolidayMatchingService;
        private HolidaySearchService _holidaySearchService;

        [SetUp]
        public void SetUp()
        {
            _mockFlightSearchService = new Mock<IFlightSearchService>();
            _mockHotelSearchService = new Mock<IHotelSearchService>();
            _mockHolidayMatchingService = new Mock<IHolidayMatchingService>();
            _holidaySearchService = new HolidaySearchService(
                _mockFlightSearchService.Object,
                _mockHotelSearchService.Object,
                _mockHolidayMatchingService.Object);
        }

        [Test]
        public void SearchHolidaysReturnsExpectedHolidayForCustomer1()
        {
            // Arrange
            var request = new SearchRequest
            {
                DepartingFrom = new List<string> { "MAN" },
                TravelingTo = "AGP",
                DepartureDate = new DateTime(2023, 7, 1),
                Duration = 7
            };

            var flights = new List<Flight>
            {
                new Flight { Id = 2, From = "MAN", To = "AGP", DepartureDate = new DateTime(2023, 7, 1), Price = 100 }
            };

            var hotels = new List<Hotel>
            {
                new Hotel { Id = 9, Name = "Hotel AGP", ArrivalDate = new DateTime(2023, 7, 1), Nights = 7, LocalAirports = new List<string> { "AGP" }, PricePerNight = 50 }
            };

            var expectedHolidays = new List<Holiday>
            {
                new Holiday
                {
                    Flight = flights[0],
                    Hotel = hotels[0],
                }
            };

            _mockFlightSearchService.Setup(s => s.Search(request)).Returns(flights);
            _mockHotelSearchService.Setup(s => s.Search(request)).Returns(hotels);
            _mockHolidayMatchingService.Setup(s => s.MatchHolidays(flights, hotels, request)).Returns(expectedHolidays);

            // Act
            var result = _holidaySearchService.SearchHolidays(request, HolidaySortType.TotalPrice).ToList();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(2, result[0].Flight.Id);
            Assert.AreEqual(9, result[0].Hotel.Id);
        }

        [Test]
        public void SearchHolidaysReturnsExpectedHolidayForCustomer2()
        {
            // Arrange
            var request = new SearchRequest
            {
                DepartingFrom = new List<string> { "LHR", "LGW", "STN" },
                TravelingTo = "PMI",
                DepartureDate = new DateTime(2023, 6, 15),
                Duration = 10
            };

            var flights = new List<Flight>
            {
                new Flight { Id = 6, From = "LHR", To = "PMI", DepartureDate = new DateTime(2023, 6, 15), Price = 200 }
            };

            var hotels = new List<Hotel>
            {
                new Hotel { Id = 5, Name = "Hotel PMI", ArrivalDate = new DateTime(2023, 6, 15), Nights = 10, LocalAirports = new List<string> { "PMI" }, PricePerNight = 80 }
            };

            var expectedHolidays = new List<Holiday>
            {
                new Holiday
                {
                    Flight = flights[0],
                    Hotel = hotels[0],
                }
            };

            _mockFlightSearchService.Setup(s => s.Search(request)).Returns(flights);
            _mockHotelSearchService.Setup(s => s.Search(request)).Returns(hotels);
            _mockHolidayMatchingService.Setup(s => s.MatchHolidays(flights, hotels, request)).Returns(expectedHolidays);

            // Act
            var result = _holidaySearchService.SearchHolidays(request, HolidaySortType.TotalPrice).ToList();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(6, result[0].Flight.Id);
            Assert.AreEqual(5, result[0].Hotel.Id);
        }

        [Test]
        public void SearchHolidaysReturnsExpectedHolidayForCustomer3()
        {
            // Arrange
            var request = new SearchRequest
            {
                DepartingFrom = new List<string> { "ANY" },
                TravelingTo = "LPA",
                DepartureDate = new DateTime(2022, 11, 10),
                Duration = 14
            };

            var flights = new List<Flight>
            {
                new Flight { Id = 7, From = "ANY", To = "LPA", DepartureDate = new DateTime(2022, 11, 10), Price = 300 }
            };

            var hotels = new List<Hotel>
            {
                new Hotel { Id = 6, Name = "Hotel LPA", ArrivalDate = new DateTime(2022, 11, 10), Nights = 14, LocalAirports = new List<string> { "LPA" }, PricePerNight = 100 }
            };

            var expectedHolidays = new List<Holiday>
            {
                new Holiday
                {
                    Flight = flights[0],
                    Hotel = hotels[0],
                }
            };

            _mockFlightSearchService.Setup(s => s.Search(request)).Returns(flights);
            _mockHotelSearchService.Setup(s => s.Search(request)).Returns(hotels);
            _mockHolidayMatchingService.Setup(s => s.MatchHolidays(flights, hotels, request)).Returns(expectedHolidays);

            // Act
            var result = _holidaySearchService.SearchHolidays(request, HolidaySortType.TotalPrice).ToList();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(7, result[0].Flight.Id);
            Assert.AreEqual(6, result[0].Hotel.Id);
        }
    }
}