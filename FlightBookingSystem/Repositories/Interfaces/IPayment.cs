using FlightBookingSystem.Models.Domain;

namespace FlightBookingSystem.Repositories.Interfaces
{
	public interface IPayment
	{
		Task<List<Payment>> GetAllAsync();
		Task<Payment?> GetByIdAsync(int id);
		Task<List<Payment>> GetByBookingIdAsync(int id);
		Task<Payment> CreateAsync(Payment payment);

		Task<Payment?> DeleteAsync(int id);
	}
}
