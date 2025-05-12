using HolidaySearch.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Core.Application.Interfaces.Sorting
{
    public interface IHolidaySortingStrategy
    {
        IEnumerable<Holiday> Sort(IEnumerable<Holiday> holidays);
    }
}
