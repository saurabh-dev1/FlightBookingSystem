using FlightBookingSystem.Models.Domain;

namespace FlightBookingSystem.Repositories.Interfaces
{
	public interface IFlightBooking
	{
		Task<List<FlightBooking>> GetAllAsync();
		Task<FlightBooking?> GetByIdAsync(int id);
		Task<FlightBooking> CreateAsync(FlightBooking booking); 
	}
}
