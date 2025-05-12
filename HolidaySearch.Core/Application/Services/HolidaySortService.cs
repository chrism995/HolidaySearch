using HolidaySearch.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Core.Application.Services
{
    public class HolidaySortService
    {
        public IEnumerable<Holiday> Sort(IEnumerable<Holiday> holidays)
        {
            return holidays.OrderBy(h => h.TotalPrice);
        }
    }
}
