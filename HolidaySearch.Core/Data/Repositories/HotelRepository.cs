using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using HolidaySearch.Core.Application.Interfaces.Repositories;
using HolidaySearch.Core.Domain;

namespace HolidaySearch.Core.Data.Repositories
{
    public class HotelRepository(string filePath) : IHotelRepository
    {
        private readonly string _filePath = filePath;

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