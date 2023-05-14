using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystem.Models.Domain
{
	public class FlightBooking
	{
		[Key]
		public int FlightBookingId { get; set; }

		[Required(ErrorMessage = "Departure City is Required")]
		[StringLength(30, ErrorMessage = "Departure City cannot be longer than 30 character")]
		[DisplayName("From")]
		public string DepartureCity { get; set; }

		[Required(ErrorMessage = "Arrival City is Required")]
		[StringLength(30, ErrorMessage = "Arrival City cannot be longer than 30 character")]
		[DisplayName("To")]
		public string ArrivalCity { get; set; }

		[Required(ErrorMessage = "Departure time is Required")]
		[DataType(DataType.DateTime, ErrorMessage = "Invalid departure time format")]
		[DisplayName("Departure Time")]
		public DateTime DepartureDateTime { get; set; }

		[Required(ErrorMessage = "Arrival time is Required")]
		[DataType(DataType.DateTime, ErrorMessage = "Invalid Arrival time format")]
		[DisplayName("Arrival Time")]
		public DateTime ArrivalDateTime { get; set; }

		[Required(ErrorMessage = "No. of Passengers is Required")]
		[DisplayName("No. of Passengers")]
		[Range(1,10, ErrorMessage = "Maximum 10 persons allow")]
		public int NoOfPassenger { get; set; }


		//Foreign Key
		
		public int UserId { get; set; }

	
		public int FlightId { get; set; }
		public int PaymentId { get; set; }


		// Navigation Property
		public User User { get; set; }
		public Flight Flight { get; set; }
		public Payment Payment { get; set; }
		public IEnumerable<Passenger> Passenger { get; set; }

	}
}
