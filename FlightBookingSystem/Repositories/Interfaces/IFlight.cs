using FlightBookingSystem.Models.Domain;
using System.Runtime.InteropServices;

namespace FlightBookingSystem.Repositories.Interfaces
{
    public interface IFlight
    {
        Task<List<Flight>> GetAllAsync();
        Task<Flight?> GetByIdAsync(int id);
		Task<List<Flight>> GetByNameAsync(string name);
		Task<Flight> CreateAsync(Flight flight);      
        Task<Flight?> UpdateAsync(int id, Flight flight);
        Task<Flight?> DeleteAsync(int id);
        Task<List<Flight>> GetByCitiesAsync(string DepartureCity, string ArrivalCity, DateTime DepartureDateTime);

		Task<List<string>> SelectedSeats(int id);

	}
}
