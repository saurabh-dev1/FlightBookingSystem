using FlightBookingSystem.Data;
using FlightBookingSystem.Models.Domain;
using FlightBookingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.Repositories
{
	public class FlightBookingRepository : IFlightBooking
	{
		private readonly FlightDbContext dbContext;

		public FlightBookingRepository(FlightDbContext dbContext)
        {
			this.dbContext = dbContext;
		}

		
		// Get All Bookings
		public async Task<List<FlightBooking>> GetAllAsync()
		{
			return await dbContext.FlightBookings.ToListAsync();
		}

		//Get Booking By id
		public async Task<FlightBooking?> GetByIdAsync(int id)
		{
			return await dbContext.FlightBookings.FirstOrDefaultAsync(m => m.FlightBookingId == id);

		}

		//Create Bookings
		public async Task<FlightBooking> CreateAsync(FlightBooking booking)
		{
			await dbContext.FlightBookings.AddAsync(booking);
			await dbContext.SaveChangesAsync();
			return booking;

		}

	}
}
