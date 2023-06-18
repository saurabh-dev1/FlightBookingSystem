using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FlightBookingSystem.Models.DTOs
{
	public class PassengerDto
	{
		[Key]
		public int PassengerId { get; set; }

		[Required(ErrorMessage = "First Name is Required")]
		[DisplayName("First Name")]
		[StringLength(20, ErrorMessage = "Maximum 20 character allow")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Last Name is Required")]
		[DisplayName("Last Name")]
		[StringLength(20, ErrorMessage = "Maximum 20 character allow")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Age is Required")]
		[DisplayName("Age")]
		public int Age { get; set; }

		[Required(ErrorMessage = "Gender is Required")]
		[DisplayName("Gender")]
		public string Gender { get; set; }

		[Required(ErrorMessage = "Mobile Number is Required")]
		[DisplayName("Mob. No.")]
		
		public string PhoneNumber { get; set; }

		[Required]
		public string AllocatedSeat { get; set; }


		//Foreign Key
		public int UserId { get; set; }
		public int FlightBookingId { get; set; }

	}
}
