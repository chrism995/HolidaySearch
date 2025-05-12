using HolidaySearch.Core.Domain.Request;
using HolidaySearch.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidaySearch.Core.Application.Interfaces;

namespace HolidaySearch.Core.Application.Services
{
    public class HotelSearchService: IHotelSearchService
    {
        private readonly IEnumerable<Hotel> _hotels;

        public HotelSearchService(IEnumerable<Hotel> hotels)
        {
            _hotels = hotels;
        }

        public IEnumerable<Hotel> Search(SearchRequest request)
        {
            return Enumerable.Empty<Hotel>();
        }
    }
}
