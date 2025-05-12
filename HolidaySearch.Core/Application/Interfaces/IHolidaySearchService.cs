using HolidaySearch.Core.Domain.Request;
using HolidaySearch.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidaySearch.Core.Domain.Enums;

namespace HolidaySearch.Core.Application.Interfaces
{
    public interface IHolidaySearchService
    {
        IEnumerable<Holiday> SearchHolidays(SearchRequest request, HolidaySortType sortType);
    }
}
