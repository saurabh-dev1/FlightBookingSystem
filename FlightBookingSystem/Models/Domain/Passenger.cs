using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightBookingSystem.Models.Domain
{
	public class Passenger
	{
		[Key]
		public int PassengerId { get; set; }

		[Required(ErrorMessage ="First Name is Required")]
		[DisplayName("First Name")]
		[StringLength(20,ErrorMessage = "Maximum 20 character allow")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Last Name is Required")]
		[DisplayName("Last Name")]
		[StringLength(20, ErrorMessage = "Maximum 20 character allow")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Age is Required")]
		[DisplayName("Age")]
		[Range(1, 100, ErrorMessage ="Age must be 1 to 100")]
		public int Age { get; set; }

		[Required(ErrorMessage = "Gender is Required")]
		[DisplayName("Gender")]
		public string Gender { get; set; }

		[Required(ErrorMessage = "Email Id is Required")]
		[DisplayName("Email Id")]
		[DataType(DataType.EmailAddress)]
		public string EmailAddress { get; set; }

		[Required(ErrorMessage = "Mobile Number is Required")]
		[DisplayName("Mob. No.")]
		[StringLength(11)]
		[Phone(ErrorMessage ="Invalid phone number")]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "Name is Required")]
		[StringLength(40, ErrorMessage = "Name cannot be longer than 40 character")]
		[DisplayName("Name")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Password is Required")]
		[DisplayName("Password")]
		[DataType(DataType.Password)]
		[MinLength(8, ErrorMessage = "Minimum 8 character Required")]
		public string Password { get; set; }


		//Foreign Key
		public int UserId { get; set; }
		public int FlightBookingId { get; set; }

		public int SeatAllocationId { get; set; }

		// Navigation Property
		public User User { get; set; }
		public FlightBooking FlightBooking { get; set; }
		public SeatAllocation SeatAllocation { get; set; }

	}
}
