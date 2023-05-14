using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FlightBookingSystem.Models.DTOs
{
	public class AdminDto
	{
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

	}
}
