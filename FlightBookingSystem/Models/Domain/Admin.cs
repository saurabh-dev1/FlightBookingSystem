using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightBookingSystem.Models.Domain
{
	public class Admin
	{
		[Key]
		public int AdminId { get; set; }

		[Required(ErrorMessage = "Name is Required")]
		[StringLength(30, ErrorMessage = "Name cannot be longer than 30 character")]
		[DisplayName("Name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Email Id is Required")]
		[DisplayName("Email Id")]
		[DataType(DataType.EmailAddress)]
		public string EmailAddress { get; set; }

		[Required(ErrorMessage = "Password is Required")]
		[DisplayName("Password")]
		[DataType(DataType.Password)]
		[MinLength(8, ErrorMessage = "Minimum 8 character Required")]
		public string Password { get; set; }

		//Foreign Key
		[Required]
		public int FlightId { get; set; }

		[Required]
		public int FlightBookingId { get; set; }

		[Required]
		public int PaymentId { get; set; }

		// Navigation Property
		public Flight Flight { get; set; }


		public FlightBooking FlightBooking { get; set; }
		public Payment Payment { get; set; }

	}
}
