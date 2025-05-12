using HolidaySearch.Core.Application.Services;
using HolidaySearch.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Tests.Services
{
    public class HolidaySortServiceTests
    {
        private HolidaySortService _holidaySortService;

        [SetUp]
        public void Setup()
        {
            _holidaySortService = new HolidaySortService();
        }

        [Test]
        public void SortsHolidaysByTotalPriceAscending()
        {
            var holidays = new List<Holiday>
            {
                new() { Flight = new Flight { Price = 250 }, Hotel = new Hotel { PricePerNight = 100, Nights = 7 } },
                new() { Flight = new Flight { Price = 200 }, Hotel = new Hotel { PricePerNight = 75, Nights = 7 } }, 
                new() { Flight = new Flight { Price = 300 }, Hotel = new Hotel { PricePerNight = 50, Nights = 7 } } 
            };

            var result = _holidaySortService.Sort(holidays).ToList();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(650, result[0].TotalPrice);
            Assert.AreEqual(725, result[1].TotalPrice);
            Assert.AreEqual(950, result[2].TotalPrice);
        }

        [Test]
        public void PreservesOrderWhenTotalPricesAreEqual()
        {
            var holidays = new List<Holiday>
            {
                new() { Flight = new Flight { Price = 200 }, Hotel = new Hotel { PricePerNight = 100, Nights = 5 } }, // Total: 700
                new() { Flight = new Flight { Price = 250 }, Hotel = new Hotel { PricePerNight = 90, Nights = 5 } }   // Total: 700
            };

            var result = _holidaySortService.Sort(holidays).ToList();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(700, result[0].TotalPrice);
            Assert.AreEqual(700, result[1].TotalPrice);
        }
    }
}
