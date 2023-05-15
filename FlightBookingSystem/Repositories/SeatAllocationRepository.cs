using FlightBookingSystem.Data;
using FlightBookingSystem.Models.Domain;
using FlightBookingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.Repositories
{
	public class SeatAllocationRepository : ISeatAllocation
	{
		private readonly FlightDbContext dbContext;

		public SeatAllocationRepository(FlightDbContext dbContext)
        {
			this.dbContext = dbContext;
		}

		

		//Get All Seat
		public async Task<List<SeatAllocation>> GetAllAsync()
		{
			return await dbContext.SeatAllocations.ToListAsync();
		}

		//get seat by id
		public async Task<SeatAllocation?> GetByIdAsync(int id)
		{
			return await dbContext.SeatAllocations.FirstOrDefaultAsync(m => m.SeatAllocationId == id);
		}

		//get seat by passenger id
		public async Task<List<SeatAllocation>> GetByPassengerIdAsync(int id)
		{
			return await dbContext.SeatAllocations.Where(m => m.PassengerId == id).ToListAsync();
		}

		//Create Seats
		public async Task<SeatAllocation> CreateAsync(SeatAllocation seatAllocation)
		{
			await dbContext.SeatAllocations.AddAsync(seatAllocation);
			await dbContext.SaveChangesAsync();
			return seatAllocation;
		}
	}
}
