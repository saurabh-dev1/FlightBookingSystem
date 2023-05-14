using FlightBookingSystem.Data;
using FlightBookingSystem.Models.Domain;
using FlightBookingSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.Repositories
{
	public class AdminRepository : IAdmin
	{
		private readonly FlightDbContext dbContext;

		public AdminRepository(FlightDbContext dbContext)
        {
			this.dbContext = dbContext;
		}

		

		public async Task<List<Admin>> GetAllAsync()
		{
			return await dbContext.Admins.ToListAsync();
		}

		public async Task<Admin?> GetByIdAsync(int id)
		{
			return await dbContext.Admins.Where(m=>m.AdminId == id).FirstOrDefaultAsync();
					
		}

		public async Task<Admin> CreateAsync(Admin admin)
		{
			await dbContext.Admins.AddAsync(admin);
			await dbContext.SaveChangesAsync();
			return admin;
		}
	}
}
