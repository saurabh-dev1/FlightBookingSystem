using FlightBookingSystem.Models.Domain;
using System.Runtime.InteropServices;

namespace FlightBookingSystem.Repositories.Interfaces
{
    public interface IFlightRepository
    {
        Task<List<Flight>> GetAllAsync();
        Task<Flight?> GetByIdAsync(int id);
        Task<Flight> CreateAsync(Flight flight);
    }
}
