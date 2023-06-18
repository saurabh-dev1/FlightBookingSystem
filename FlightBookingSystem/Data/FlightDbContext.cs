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
	
		public DbSet<Payment> Payments { get; set; }
		public DbSet<FlightBooking> FlightBookings { get; set; }



		/*protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//Seed Data for FlightBookings
			*//*var flightBookings = new List<FlightBooking>()
			{
				new FlightBooking()
				{
					FlightBookingId = 1,
					DepartureCity = "PUNE",
					ArrivalCity = "JAIPUR",
					DepartureDateTime = DateTime.Now,
					ArrivalDateTime = DateTime.Now,
					NoOfPassenger = 2,
					UserId = 1,
					PaymentId = 1,
					FlightId = 1
				},
				new FlightBooking()
				{
					FlightBookingId = 2,
					DepartureCity = "PUNE",
					ArrivalCity = "MUMBAI",
					DepartureDateTime = DateTime.Now,
					ArrivalDateTime = DateTime.Now,
					NoOfPassenger = 1,
					UserId = 2,
					PaymentId = 2,
					FlightId = 2
				}
			};

			// Seed Data for Passenger
			var passenger = new List<Passenger>()
			{
				new Passenger()
				{
					PassengerId = 1,
					FirstName = "Mudit",
					LastName = "Jain",
					Gender = "Male",
					Age = 22,
					EmailAddress = "Mudit@gmail.com",
					Password = "123456789",
					PhoneNumber = "8824975612",
					UserName = "Muditj84",
					FlightBookingId = 1,
					SeatAllocationId = 1
				},
				new Passenger()
				{
					PassengerId = 2,
					FirstName = "Garima",
					LastName = "Yadav",
					Gender = "Female",
					Age = 22,
					EmailAddress = "Garima@gmail.com",
					Password = "123256789",
					PhoneNumber = "8892975612",
					UserName = "GarimaY84",
					FlightBookingId = 1,
					SeatAllocationId = 1
				}
			};

			var payment = new List<Payment>()
			{
				new Payment()
				{
					PaymentId = 1,
					PayemntTime = DateTime.Now,
					PaymentMethod = "Credit Card",
					PaymentStatus = true,
					TotalPrice = 1254,
					UserId = 1,
					FlightBookingId = 1
				},
				new Payment()
				{
					PaymentId = 2,
					PayemntTime = DateTime.Now,
					PaymentMethod = "debit Card",
					PaymentStatus = true,
					TotalPrice = 1259,
					UserId = 2,
					FlightBookingId = 2
				}
			};

			var seatAllocation = new List<SeatAllocation>()
			{
				new SeatAllocation()
				{
					SeatAllocationId = 1,
					SeatNumber = "25",
					SeatAllocated = true,
					SeatClass = "1AC",
					SeatAvailableId = 1,
					PassengerId = 1
				},

				new SeatAllocation()
				{
					SeatAllocationId = 2,
					SeatNumber = "29",
					SeatAllocated = true,
					SeatClass = "3AC",
					SeatAvailableId = 2,
					PassengerId = 2
				}
			};

			var seatAvailable = new List<SeatAvailable>()
			{
				new SeatAvailable()
				{
					SeatAvailableId = 1,
					SeatBooked = 36,
					TotalSeats = 100,
					IsAvailable = true,
					FlightId = 1
					
				},
				new SeatAvailable()
				{
					SeatAvailableId = 2,
					SeatBooked = 40,
					TotalSeats = 200,
					IsAvailable = true,
					FlightId = 2
				}
			};
			var user = new List<User>()
			{
				new User()
				{
					UserId = 1,
					UserName = "Saurabh",
					EmailAddress = "saurabh@gmail.com",
					Password =  "5245489966"
				},
				new User()
				{
					UserId = 2,
					UserName = "Rohit",
					EmailAddress = "saurabh@gmail.com",
					Password =  "5245489966"
				}
			};

			var flight = new List<Flight>()
			{
				new Flight()
				{
					FlightId = 1,
					FlightName = "UDAAN",
					FlightNumber = "5845",
					DepartureCity = "PUNE",
					ArrivalCity = "JAIPUR",
					DepartureCityCode = "PUN",
					ArrivalCityCode = "JAI",
					DepartureDateTime = DateTime.Now,
					ArrivalDateTime = DateTime.Now,
					BasePrice = 2000
				}
			};


			modelBuilder.Entity<FlightBooking>().HasData(flightBookings);
			modelBuilder.Entity<Passenger>().HasData(passenger);
			modelBuilder.Entity<Payment>().HasData(payment);
			modelBuilder.Entity<SeatAllocation>().HasData(seatAllocation);
			modelBuilder.Entity<SeatAvailable>().HasData(seatAvailable);
			modelBuilder.Entity<User>().HasData(user);
			modelBuilder.Entity<Flight>().HasData(flight);*//*



			

			
			
		}

*/


		
		
	}
}
