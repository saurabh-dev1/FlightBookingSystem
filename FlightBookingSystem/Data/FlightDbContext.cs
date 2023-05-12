using FlightBookingSystem.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.Data
{
	public class FlightDbContext : DbContext
	{
        public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options)
        {
            
        }

        public DbSet<Flight> Flights { get; set; }
		public DbSet<Passenger> Passengers { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Admin> Admins { get; set; }
		public DbSet<SeatAvailable> SeatAvailables { get; set; }
		public DbSet<SeatAllocation> SeatAllocations { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<FlightBooking> FlightBookings { get; set; }
	}
}
