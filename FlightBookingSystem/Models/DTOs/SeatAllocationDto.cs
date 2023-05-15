using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FlightBookingSystem.Models.DTOs
{
	public class SeatAllocationDto
	{
		public int SeatAllocationId { get; set; }

		[DisplayName("Seat Number")]
		public string SeatNumber { get; set; }

		[Required(ErrorMessage = "Enter Class")]
		[DisplayName("Class")]
		public string SeatClass { get; set; }

		[DisplayName("Seat Allocated")]
		public bool SeatAllocated { get; set; }

		

		public int PassengerId { get; set; }
	}
}
