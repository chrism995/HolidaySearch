using HolidaySearch.Core.Domain.Request;
using HolidaySearch.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Core.Application.Interfaces
{
    public interface IHolidayMatchingService
    {
        IEnumerable<Holiday> MatchHolidays(IEnumerable<Flight> flights, IEnumerable<Hotel> hotels, SearchRequest request);
    }
}
