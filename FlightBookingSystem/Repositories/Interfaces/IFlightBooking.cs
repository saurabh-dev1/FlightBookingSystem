using FlightBookingSystem.Models.Domain;

namespace FlightBookingSystem.Repositories.Interfaces
{
	public interface IFlightBooking
	{
		Task<List<FlightBooking>> GetAllAsync();
		Task<FlightBooking?> GetByIdAsync(int id);
		Task<FlightBooking> CreateAsync(FlightBooking booking); 
		Task<FlightBooking?> UpdateAsync(int id, FlightBooking booking);
		Task<FlightBooking?> DeleteAsync(int id);

		Task<List<FlightBooking>> GetByUserIdAsync(int id);

		Task<List<FlightBooking>> GetByUserAndFlightId(int userId, int flightId);
	}
}
