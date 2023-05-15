using FlightBookingSystem.Models.Domain;

namespace FlightBookingSystem.Repositories.Interfaces
{
	public interface IPayment
	{
		Task<List<Payment>> GetAllAsync();
		Task<Payment?> GetByIdAsync(int id);
		Task<List<Payment>> GetByBookinIdAsync(int id);
		Task<Payment> CreateAsync(Payment payment);

	}
}
