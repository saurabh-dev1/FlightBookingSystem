﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using FlightBookingSystem.Models.Domain;

namespace FlightBookingSystem.Models.DTOs
{
	public class UserDto
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

		[Required(ErrorMessage = "PhoneNo is Required")]
		public string PhoneNo { get; set; }

		public string? Roles { get; set; } = "User";


	}
}
