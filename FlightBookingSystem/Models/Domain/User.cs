using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystem.Models.Domain
{
	public class User
	{
		[Key]
		public int UserId { get; set; }

		[Required(ErrorMessage = "Name is Required")]
		[StringLength(40, ErrorMessage = "Name cannot be longer than 40 character")]
		[DisplayName("Name")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Email Id is Required")]
		[DisplayName("Email Id")]
		[DataType(DataType.EmailAddress)]
		public string EmailAddress { get; set; }

		[Required(ErrorMessage = "Password is Required")]
		[DisplayName("Password")]
		[DataType(DataType.Password)]
		[MinLength(8, ErrorMessage = "Minimum 8 character Required")]
		public string Password { get; set; }



		public int AdminId { get; set; }
		//Navigation Property
		public Admin Admin { get; set; }
		public IEnumerable<FlightBooking> FlightBooking { get; set; }

		public IEnumerable<Payment> Payment { get; set; }
		public IEnumerable<Passenger> Passenger{ get; set; }
	}
}
