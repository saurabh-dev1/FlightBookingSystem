using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystem.Models.Domain
{
	public class SeatAllocation
	{
		[Key]
		public int SeatAllocationId { get; set; }

		[DisplayName("Seat Number")]
		public string SeatNumber { get; set;}

		[Required(ErrorMessage ="Enter Class")]
		[DisplayName("Class")]
		public string SeatClass { get; set;}

		[DisplayName("Seat Allocated")]
		public bool SeatAllocated { get; set;}

		//Foreign Key

		public int PassengerId { get; set; }

		// Navigation Property
		public Passenger Passenger { get; set; }

		
	}
}
