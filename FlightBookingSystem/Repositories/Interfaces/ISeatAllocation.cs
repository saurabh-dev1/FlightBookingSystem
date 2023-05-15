using FlightBookingSystem.Models.Domain;

namespace FlightBookingSystem.Repositories.Interfaces
{
	public interface ISeatAllocation
	{
		Task<List<SeatAllocation>> GetAllAsync();
		Task<SeatAllocation?> GetByIdAsync(int id);
		Task<List<SeatAllocation>> GetByPassengerIdAsync(int id);
		Task<SeatAllocation> CreateAsync(SeatAllocation seatAllocation);
	}
}
