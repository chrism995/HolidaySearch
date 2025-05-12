using System.Text.Json;
using HolidaySearch.Core.Application.Interfaces;
using HolidaySearch.Core.Domain;

namespace HolidaySearch.Data.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly string _filePath;

        public FlightRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            if (!File.Exists(_filePath))
                throw new FileNotFoundException($"The file {_filePath} was not found.");

            var jsonData = File.ReadAllText(_filePath);
            var flights = JsonSerializer.Deserialize<IEnumerable<Flight>>(jsonData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return flights ?? new List<Flight>();
        }
    }
}