using HolidaySearch.Core.Application.Interfaces.Sorting;
using HolidaySearch.Core.Domain.Enums;


namespace HolidaySearch.Core.Application.Services.Sorting
{
    public static class HolidaySortFactory
    {
        public static IHolidaySortingStrategy Create(HolidaySortType sortType)
        {
            return sortType switch
            {
                HolidaySortType.FlightPrice => new SortByFlightPrice(),
                _ => new SortByTotalPrice()
            };
        }
    }

}
