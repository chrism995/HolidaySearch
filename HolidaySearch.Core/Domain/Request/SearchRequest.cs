using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Core.Domain.Request
{
    public class SearchRequest
    {
        public List<string> DepartingFrom { get; set; }
        public string TravelingTo { get; set; }
        public DateTime DepartureDate { get; set; }
        public int Duration { get; set; }
    }
}
