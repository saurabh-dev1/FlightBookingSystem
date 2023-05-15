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

		//Update Booking Details
		public async Task<FlightBooking?> UpdateAsync(int id, FlightBooking booking)
		{
			var existBooking = await dbContext.FlightBookings.FirstOrDefaultAsync(m =>m.FlightBookingId == id);
			if (existBooking == null)
			{
				return null;
			}

			existBooking.DepartureDateTime = booking.DepartureDateTime;
			existBooking.ArrivalDateTime = booking.ArrivalDateTime;
			existBooking.DepartureCity = booking.DepartureCity;
			existBooking.ArrivalCity = booking.DepartureCity;
			existBooking.NoOfPassenger = booking.NoOfPassenger;
			

			await dbContext.SaveChangesAsync();
			return existBooking;
		}

		//Delete Bookings
		public async Task<FlightBooking?> DeleteAsync(int id)
		{
			var bookinExist = await dbContext.FlightBookings.FirstOrDefaultAsync(m => m.FlightBookingId==id);
			if (bookinExist == null)
			{
				return null;
			}
			dbContext.FlightBookings.Remove(bookinExist);
			await dbContext.SaveChangesAsync();
			return bookinExist;
		}


		//Get By User Id
		public async Task<List<FlightBooking>> GetByUserIdAsync(int id)
		{
			var booking = await dbContext.FlightBookings.Where(m=>m.UserId==id).ToListAsync();
			return booking;
		
		}
	}
}
