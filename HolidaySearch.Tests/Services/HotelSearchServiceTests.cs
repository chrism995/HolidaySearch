using HolidaySearch.Core.Application.Services;
using HolidaySearch.Core.Domain;
using HolidaySearch.Core.Domain.Request;

namespace HolidaySearch.Tests.Services
{
    public class HotelSearchServiceTests
    {
        [Test]
        public void ShouldReturnHotelMatchingArrivalDateAirportAndDuration()
        {
            var hotels = new List<Hotel>
            {
                new Hotel
                {
                    Id = 1,
                    Name = "Nh Malaga",
                    ArrivalDate = new DateTime(2023, 7, 1),
                    Nights = 7,
                    PricePerNight = 90,
                    LocalAirports = new List<string> { "AGP" }
                }
            };

            var request = new SearchRequest
            {
                DepartureDate = new DateTime(2023, 7, 1),
                TravelingTo = "AGP",
                Duration = 7
            };

            var service = new HotelSearchService(hotels);
            var results = service.Search(request).ToList();

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(1, results.First().Id);
        }
    }
}
