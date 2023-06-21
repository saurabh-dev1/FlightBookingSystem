using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FlightBookingSystem.Models.DTOs
{
	public class CreatePaymentDto
	{

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



		public int FlightBookingId { get; set; }
	}
}
