﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FlightBookingSystem.Models.DTOs
{
	public class LoginRequestDto
	{
		[Required(ErrorMessage = "Name is Required")]
		[StringLength(40, ErrorMessage = "Name cannot be longer than 40 character")]
		[DisplayName("Name")]
		public string UserName { get; set; }


		[Required(ErrorMessage = "Password is Required")]
		[DisplayName("Password")]
		[DataType(DataType.Password)]
		[MinLength(8, ErrorMessage = "Minimum 8 character Required")]
		public string Password { get; set; }

		public string? Roles { get; set; } 
		public string? Token { get; set; }

	}
}
