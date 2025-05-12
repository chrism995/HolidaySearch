using HolidaySearch.Core.Application.Services;
using HolidaySearch.Core.Domain;
using HolidaySearch.Core.Domain.Request;

namespace HolidaySearch.Tests
{
    [TestFixture]
    public class HolidayMatchingServiceTests
    {
        private HolidayMatchingService _holidayMatchingService;

        [SetUp]
        public void SetUp()
        {
            _holidayMatchingService = new HolidayMatchingService();
        }

        [Test]
        public void MatchHolidaysReturnsExpectedHoliday()
        {
            // Arrange
            var flights = new List<Flight>
            {
                new Flight { Id = 1, To = "AGP", DepartureDate = new DateTime(2023, 7, 1), Price = 100 }
            };

            var hotels = new List<Hotel>
            {
                new Hotel { Id = 1, ArrivalDate = new DateTime(2023, 7, 1), Nights = 7, LocalAirports = new List<string> { "AGP" }, PricePerNight = 50 }
            };

            var request = new SearchRequest
            {
                TravelingTo = "AGP",
                DepartureDate = new DateTime(2023, 7, 1),
                Duration = 7
            };

            // Act
            var result = _holidayMatchingService.MatchHolidays(flights, hotels, request).ToList();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0].Flight.Id);
            Assert.AreEqual(1, result[0].Hotel.Id);
        }

        [Test]
        public void MatchHolidaysReturnsEmptyListWhenNoMatches()
        {
            // Arrange
            var flights = new List<Flight>
            {
                new Flight { Id = 1, To = "XYZ", DepartureDate = new DateTime(2023, 7, 1), Price = 100 }
            };

            var hotels = new List<Hotel>
            {
                new Hotel { Id = 1, ArrivalDate = new DateTime(2023, 7, 1), Nights = 7, LocalAirports = new List<string> { "ABC" }, PricePerNight = 50 }
            };

            var request = new SearchRequest
            {
                TravelingTo = "AGP",
                DepartureDate = new DateTime(2023, 7, 1),
                Duration = 7
            };

            // Act
            var result = _holidayMatchingService.MatchHolidays(flights, hotels, request).ToList();

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void MatchHolidaysReturnsAllMatchingHolidaysWhenMultipleMatches()
        {
            // Arrange
            var flights = new List<Flight>
            {
                new Flight { Id = 1, To = "AGP", DepartureDate = new DateTime(2023, 7, 1), Price = 100 },
                new Flight { Id = 2, To = "AGP", DepartureDate = new DateTime(2023, 7, 1), Price = 150 }
            };

            var hotels = new List<Hotel>
            {
                new Hotel { Id = 1, ArrivalDate = new DateTime(2023, 7, 1), Nights = 7, LocalAirports = new List<string> { "AGP" }, PricePerNight = 50 },
                new Hotel { Id = 2, ArrivalDate = new DateTime(2023, 7, 1), Nights = 7, LocalAirports = new List<string> { "AGP" }, PricePerNight = 60 }
            };

            var request = new SearchRequest
            {
                TravelingTo = "AGP",
                DepartureDate = new DateTime(2023, 7, 1),
                Duration = 7
            };

            // Act
            var result = _holidayMatchingService.MatchHolidays(flights, hotels, request).ToList();

            // Assert
            Assert.AreEqual(4, result.Count);
        }

        [Test]
        public void MatchHolidaysReturnsEmptyListWhenEmptyInput()
        {
            // Arrange
            var flights = new List<Flight>();
            var hotels = new List<Hotel>();
            var request = new SearchRequest
            {
                TravelingTo = "AGP",
                DepartureDate = new DateTime(2023, 7, 1),
                Duration = 7
            };

            // Act
            var result = _holidayMatchingService.MatchHolidays(flights, hotels, request).ToList();

            // Assert
            Assert.AreEqual(0, result.Count);
        }
    }
}