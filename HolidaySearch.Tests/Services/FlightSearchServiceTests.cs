using HolidaySearch.Core.Application.Services;
using HolidaySearch.Core.Domain;
using HolidaySearch.Core.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Tests.Services
{
    public class FlightSearchServiceTests
    {
        [Test]
        public void ShouldReturnMatchingFlight_WhenDepartureAirportAndDateMatch()
        {
            var flights = new List<Flight>
            {
                new() {
                    Id = 1,
                    From = "MAN",
                    To = "AGP",
                    DepartureDate = new DateTime(2023, 7, 1),
                    Price = 200
                }
            };

            var request = new SearchRequest
            {
                DepartingFrom = new List<string> { "MAN" },
                TravelingTo = "AGP",
                DepartureDate = new DateTime(2023, 7, 1),
                Duration = 7
            };

            var service = new FlightSearchService(flights);
            var result = service.Search(request).ToList();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0].Id);
        }

    }
}
