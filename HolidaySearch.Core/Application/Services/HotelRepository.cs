using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using HolidaySearch.Core.Application.Interfaces;
using HolidaySearch.Core.Domain;

namespace HolidaySearch.Data.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly string _filePath;

        public HotelRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            if (!File.Exists(_filePath))
                throw new FileNotFoundException($"The file {_filePath} was not found.");

            var jsonData = File.ReadAllText(_filePath);
            var hotels = JsonSerializer.Deserialize<IEnumerable<Hotel>>(jsonData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return hotels ?? new List<Hotel>();
        }
    }
}