using FlightBookingSystem.Models.Domain;

namespace FlightBookingSystem.Repositories.Interfaces
{
	public interface IPassenger
	{
		Task<List<Passenger>> GetAllAsync();
		Task<Passenger?> GetByIdAsync(int id);
		Task<List<Passenger>> GetByBookingIdAsync(int id);
		Task<Passenger> CreateAsync(Passenger passenger);
		Task<Passenger?> UpdateAsync(int id, Passenger passenger);
		Task<Passenger?> DeleteAsync(int id);
	}
}
