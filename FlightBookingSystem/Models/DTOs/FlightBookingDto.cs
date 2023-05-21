using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using FlightBookingSystem.Models.Domain;
using Microsoft.AspNetCore.SignalR;

namespace FlightBookingSystem.Models.DTOs
{
	public class FlightBookingDto
	{
		
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
		
		public int NoOfPassenger { get; set; }

		public int FlightId { get; set; }
		
		public int UserId { get; set; }
		/*public FlightDto Flight { get; set; }*/
		/*public UserDto User { get; set; }*/
	}
}
