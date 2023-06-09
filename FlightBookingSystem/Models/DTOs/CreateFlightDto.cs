using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FlightBookingSystem.Models.DTOs
{
	public class CreateFlightDto
	{
		[Required(ErrorMessage = "Flight Name is Required")]
		[StringLength(20, ErrorMessage = "Flight name cannot be longer than 20 character")]
		[DisplayName("Flight Name")]
		public string FlightName { get; set; }

		[Required(ErrorMessage = "Flight Number is Required")]
		[StringLength(10, ErrorMessage = "Flight number cannot be longer than 10 character")]
		[DisplayName("Flight Number")]
		public string FlightNumber { get; set; }

		[Required(ErrorMessage = "Departure City is Required")]
		[StringLength(30, ErrorMessage = "Departure City cannot be longer than 30 character")]
		[DisplayName("From")]
		public string DepartureCity { get; set; }

		[Required(ErrorMessage = "Arrival City is Required")]
		[StringLength(30, ErrorMessage = "Arrival City cannot be longer than 30 character")]
		[DisplayName("To")]
		public string ArrivalCity { get; set; }

		[Required(ErrorMessage = "Departure time is Required")]
		[DataType(DataType.Date, ErrorMessage = "Invalid departure time format")]
		[DisplayName("Departure Time")]
		public DateTime DepartureDateTime { get; set; }

		[Required(ErrorMessage = "Price is Required")]
		[DisplayName("Base Price")]
		public double BasePrice { get; set; }

	}
}
