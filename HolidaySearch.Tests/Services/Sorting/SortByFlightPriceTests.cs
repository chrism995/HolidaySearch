using HolidaySearch.Core.Application.Services.Sorting;
using HolidaySearch.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Tests.Services.Sorting
{
    public class SortByFlightPriceTests
    {
        private SortByFlightPrice _strategy;

        [SetUp]
        public void Setup()
        {
            _strategy = new SortByFlightPrice();
        }

        [Test]
        public void SortsHolidaysByFlightPriceAscending()
        {
            var holidays = new List<Holiday>
            {
                new() { Flight = new Flight { Price = 300 }, Hotel = new Hotel { PricePerNight = 100, Nights = 5 } },
                new() { Flight = new Flight { Price = 150 }, Hotel = new Hotel { PricePerNight = 100, Nights = 5 } },
                new() { Flight = new Flight { Price = 200 }, Hotel = new Hotel { PricePerNight = 100, Nights = 5 } }
            };

            var result = _strategy.Sort(holidays).ToList();

            Assert.AreEqual(150, result[0].Flight.Price);
            Assert.AreEqual(200, result[1].Flight.Price);
            Assert.AreEqual(300, result[2].Flight.Price);
        }

        [Test]
        public void PreservesOrderWhenFlightPricesAreEqual()
        {
            var holidays = new List<Holiday>
            {
                new() { Flight = new Flight { Price = 250 }, Hotel = new Hotel { Id = 1 } },
                new() { Flight = new Flight { Price = 250 }, Hotel = new Hotel { Id = 2 } }
            };

            var result = _strategy.Sort(holidays).ToList();

            Assert.AreEqual(1, result[0].Hotel.Id);
            Assert.AreEqual(2, result[1].Hotel.Id);
        }
    }
}
