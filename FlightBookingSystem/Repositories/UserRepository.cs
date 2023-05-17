using FlightBookingSystem.Data;
using FlightBookingSystem.Models.Domain;
using FlightBookingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.Repositories
{
	public class UserRepository : IUser
	{
		private readonly FlightDbContext flightDbContext;

		public UserRepository(FlightDbContext flightDbContext)
        {
			this.flightDbContext = flightDbContext;
		}

		// Create User
		public async Task<User> CreateAsync(User user)
		{
			await flightDbContext.Users.AddAsync(user);
			await flightDbContext.SaveChangesAsync();
			return user;
		}

		
		//Get All Users
		public async Task<List<User>> GetAllAsync()
		{
			return await flightDbContext.Users.ToListAsync();
		}

		//Get User By id
		public async Task<User?> GetByIdAsync(int id)
		{
			return await flightDbContext.Users.FirstOrDefaultAsync(m =>m.UserId == id);
		}

		//Update User 
		public async Task<User?> UpdateAsync(int id, User user)
		{
			var existUser = await flightDbContext.Users.FirstOrDefaultAsync(u => u.UserId == id);
			if (existUser == null)
			{
				return null;
			}
			existUser.UserName = user.UserName;
			existUser.Password = user.Password;
			existUser.EmailAddress = user.EmailAddress;

			await flightDbContext.SaveChangesAsync();
			return existUser;
		}

		//Delete User
		public async Task<User?> DeleteAsync(int id)
		{
			var existUser = await flightDbContext.Users.FirstOrDefaultAsync(u => u.UserId == id);
			if (existUser == null)
			{
				return null;
			}

			flightDbContext.Users.Remove(existUser);
			await flightDbContext.SaveChangesAsync();
			return existUser;
		}

	}
}
