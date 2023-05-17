using FlightBookingSystem.Models.Domain;

namespace FlightBookingSystem.Repositories.Interfaces
{
	public interface IUser
	{
		Task<List<User>> GetAllAsync();
		Task<User?> GetByIdAsync(int id);
		Task<User> CreateAsync(User user);
		Task<User?> UpdateAsync(int id,User user);
		Task<User?> DeleteAsync(int id);
	}
}
