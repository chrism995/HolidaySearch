using HolidaySearch.Core.Application.Interfaces;
using HolidaySearch.Core.Domain;
using HolidaySearch.Core.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Core.Application.Services
{
    public class HolidayMatchingService : IHolidayMatchingService
    {
        public IEnumerable<Holiday> MatchHolidays(IEnumerable<Flight> flights, IEnumerable<Hotel> hotels, SearchRequest request)
        {
            return new List<Holiday>();
        }
    }
}
