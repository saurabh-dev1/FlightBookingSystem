using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystem.Models.Domain
{
	public class Payment
	{
		[Key]
		public int PaymentId { get; set; }

		[Required]
		[DisplayName("Payment Date/Time")]
		public DateTime PayemntTime { get; set; }

		[Required]
		[DisplayName("Payment Method")]
		public string PaymentMethod { get; set; }

		[Required]
		[DisplayName("Total Price")]
		public double TotalPrice { get; set; }

		[Required]
		[DisplayName("Payment Status")]
		public bool PaymentStatus { get; set; }


		//Foreign Key
		[Required]
		public int FlightBookingId { get; set; }

		[Required]
		public int SeatAllocationId { get; set; }

		// Navigation Property
		public FlightBooking FlightBooking  { get; set; }
		public SeatAllocation SeatAllocation { get; set; }
	}
}
