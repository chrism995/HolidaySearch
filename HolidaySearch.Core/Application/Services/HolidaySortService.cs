using HolidaySearch.Core.Application.Interfaces.Sorting;
using HolidaySearch.Core.Application.Interfaces;
using HolidaySearch.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Core.Application.Services
{
    public class HolidaySortService : IHolidaySortService
    {
        private readonly IHolidaySortingStrategy _strategy;

        public HolidaySortService(IHolidaySortingStrategy strategy)
        {
            _strategy = strategy;
        }

        public IEnumerable<Holiday> Sort(IEnumerable<Holiday> holidays)
        {
            return _strategy.Sort(holidays);
        }
    }
}
