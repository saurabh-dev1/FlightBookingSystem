using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystem.Models.Domain
{
	public class SeatAvailable
	{
		[Key]
		public int SeatAvailableId { get; set; }

		[Required]
		[DisplayName("Total Seats")]
		[MaxLength(800, ErrorMessage ="Max 800 seats")]
		public int TotalSeats { get; set;}

		[Required]
		[DisplayName("Seats Booked")]
		public int SeatBooked { get; set; }

		//Foreign Key
		[Required]
		public int FlightId { get; set; }

		// Navigation Property
		public Flight Flight { get; set; }

	}
}
