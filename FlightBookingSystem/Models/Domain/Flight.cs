﻿using FlightBookingSystem.Repositories.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystem.Models.Domain
{
	public class Flight
	{
		[Key]
		public int FlightId { get; set; }


		[StringLength(20, ErrorMessage = "Flight name cannot be longer than 20 character")]
		[DisplayName("Flight Name")]
		public string FlightName { get; set; }


		[StringLength(10, ErrorMessage = "Flight number cannot be longer than 10 character")]
		[DisplayName("Flight Number")]
		public string FlightNumber { get; set; }

		[StringLength(30, ErrorMessage = "Departure City cannot be longer than 30 character")]
		[DisplayName("From")]
		public string DepartureCity { get; set; }

		[StringLength(30, ErrorMessage = "Arrival City cannot be longer than 30 character")]
		[DisplayName("To")]
		public string ArrivalCity { get; set; }

		[Required(ErrorMessage = "Departure time is Required")]
		[DataType(DataType.Date, ErrorMessage = "Invalid departure time format")]
		[DisplayName("Departure Time")]
		public DateTime DepartureDateTime { get; set; }

		[Required(ErrorMessage = "Arrival time is Required")]
		[DataType(DataType.Date, ErrorMessage = "Invalid Arrival time format")]
		[DisplayName("Arrival Time")]
		public DateTime ArrivalDateTime { get; set; }


		[Required(ErrorMessage = "Price is Required")]
		[DisplayName("Base Price")]
		public double BasePrice { get; set; }

		[Required]
		[DisplayName("Total Seats")]

		public int TotalSeats { get; set; }

		[Required]
		[DisplayName("Available Seats")]
		public int AvailableSeats { get; set; }

		//Navigation Properties
		public IEnumerable<FlightBooking> FlightBooking { get; set; }

		public int GetAvailableSeats()
		{
			int allocatedSeats = FlightBooking?.Sum(fb => fb.Passenger?.Count() ?? 0) ?? 0;
			int availableSeats = TotalSeats - allocatedSeats;

			// Ensure the available seats count is not negative
			if (availableSeats < 0)
			{
				availableSeats = 0;
			}

			return availableSeats;
		}
	}
}