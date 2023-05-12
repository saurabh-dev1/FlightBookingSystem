using FlightBookingSystem.Data;
using FlightBookingSystem.Models.Domain;
using FlightBookingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.Repositories
{
    public class FlightRepository : IFlightRepository
	{
		private readonly FlightDbContext dbContext;

		public FlightRepository(FlightDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

		

		public async Task<List<Flight>> GetAllAsync()
		{
			return await dbContext.Flights.ToListAsync();
		}

		public async Task<Flight?> GetByIdAsync(int id)
		{
			return await dbContext.Flights.FirstOrDefaultAsync(m => m.FlightId == id);
		}

		public async Task<Flight> CreateAsync(Flight flight)
		{
			await dbContext.Flights.AddAsync(flight);
			await dbContext.SaveChangesAsync();
			return flight;
		}
	}
}
