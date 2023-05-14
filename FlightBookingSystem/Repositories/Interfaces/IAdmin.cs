using FlightBookingSystem.Models.Domain;

namespace FlightBookingSystem.Repositories.Interfaces
{
	public interface IAdmin
	{
		Task<List<Admin>> GetAllAsync();
		Task<Admin?> GetByIdAsync(int id);
		Task<Admin> CreateAsync(Admin admin);
	}
}
