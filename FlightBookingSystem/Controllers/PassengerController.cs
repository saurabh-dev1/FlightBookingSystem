﻿using FlightBookingSystem.Models.Domain;
using FlightBookingSystem.Models.DTOs;
using FlightBookingSystem.Repositories;
using FlightBookingSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace FlightBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PassengerController : ControllerBase
	{
		private readonly IPassenger passengerRepository;
		private readonly IFlightBooking flightBooking;
		private readonly IUser User;

		public PassengerController(IPassenger passengerRepository, IFlightBooking flightBooking, IUser User)
		{
			this.passengerRepository = passengerRepository;
			this.flightBooking = flightBooking;
			this.User = User;
		}

		// Get All Passengers
		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			try
			{
				var passengers = await passengerRepository.GetAllAsync();

				// Map Domain model to Dto
				var passengerDto = new List<PassengerDto>();
				foreach (var passenger in passengers)
				{
					passengerDto.Add(new PassengerDto()
					{
						PassengerId = passenger.PassengerId,
						FirstName = passenger.FirstName,
						LastName = passenger.LastName,
						Age = passenger.Age,
						Gender = passenger.Gender,
						PhoneNumber = passenger.PhoneNumber,
						AllocatedSeat = passenger.AllocatedSeat,
						UserId = passenger.UserId,
						FlightBookingId = passenger.FlightBookingId
					});
				}

				return Ok(passengerDto);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while fetching passengers.");
			}
		}

		//Create Passenger
		[HttpPost]

		public async Task<IActionResult> CreateAsync([FromBody] CreatePassengerDto passengerDto)
		{
			try
			{
				// Map Dto to Domain model
				var passenger = new Passenger
				{
					FirstName = passengerDto.FirstName,
					LastName = passengerDto.LastName,
					Age = passengerDto.Age,
					Gender = passengerDto.Gender,
					PhoneNumber = passengerDto.PhoneNumber,
					AllocatedSeat = passengerDto.AllocatedSeat,
					UserId = passengerDto.UserId,
					FlightBookingId = passengerDto.FlightBookingId
				};

				// Save the passenger entity
				await passengerRepository.CreateAsync(passenger);

				// Map Domain model back to Dto
				var passengerDto1 = new PassengerDto
				{
					PassengerId = passenger.PassengerId,
					FirstName = passenger.FirstName,
					LastName = passenger.LastName,
					Age = passenger.Age,
					Gender = passenger.Gender,
					PhoneNumber = passenger.PhoneNumber,
					AllocatedSeat = passenger.AllocatedSeat,
					UserId = passenger.UserId,
					FlightBookingId = passenger.FlightBookingId
				};
				return Ok(passengerDto1);
			}
			catch (Exception )
			{
				return StatusCode(500, "An error occurred while creating the passenger.");
			}
		}


		//Get Passenger By id
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
		{
			try
			{
				var passenger = await passengerRepository.GetByIdAsync(id);
				if (passenger == null)
				{
					return NotFound();
				}

				// Map Domain model to Dto
				var passengerDto = new PassengerDto
				{
					PassengerId = passenger.PassengerId,
					FirstName = passenger.FirstName,
					LastName = passenger.LastName,
					Age = passenger.Age,
					Gender = passenger.Gender,
					PhoneNumber = passenger.PhoneNumber,
					AllocatedSeat = passenger.AllocatedSeat,
					UserId = passenger.UserId,
					FlightBookingId = passenger.FlightBookingId
				};

				return Ok(passengerDto);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while fetching the passenger by ID.");
			}
		}


		//Get Passenger By Booking Id
		[HttpGet]
		[Route("FlightBooking/{id}")]
		public async Task<IActionResult> GetByUserIdAsync([FromRoute] int id)
		{
			try
			{
				var passengers = await passengerRepository.GetByBookingIdAsync(id);
				var passengerDto = new List<PassengerDto>();
				foreach (var passenger in passengers)
				{
					passengerDto.Add(new PassengerDto()
					{
						PassengerId = passenger.PassengerId,
						FirstName = passenger.FirstName,
						LastName = passenger.LastName,
						Age = passenger.Age,
						Gender = passenger.Gender,
						PhoneNumber = passenger.PhoneNumber,
						AllocatedSeat = passenger.AllocatedSeat,
						UserId = passenger.UserId,
						FlightBookingId = passenger.FlightBookingId
					});
				}

				if (passengers.Count == 0)
				{
					return NotFound();
				}
				else if (passengers.Count == 1)
				{
					return Ok(passengerDto[0]);
				}
				return Ok(passengerDto);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while fetching passengers by user ID.");
			}
		}


		//Update Passenger
		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] PassengerDto passengerDto)
		{
			try
			{
				// Map Dto to Domain model
				var passenger = new Passenger()
				{
					PassengerId = passengerDto.PassengerId,
					FirstName = passengerDto.FirstName,
					LastName = passengerDto.LastName,
					Age = passengerDto.Age,
					Gender = passengerDto.Gender,
					PhoneNumber = passengerDto.PhoneNumber,
					AllocatedSeat = passengerDto.AllocatedSeat,
					UserId = passengerDto.UserId,
					FlightBookingId = passengerDto.FlightBookingId
				};

				// Check if booking exists and update
				passenger = await passengerRepository.UpdateAsync(id, passenger);
				if (passenger == null)
				{
					return NotFound();
				}

				// Map Dto to Domain model
				passenger.PassengerId = passengerDto.PassengerId;
				passenger.FirstName = passengerDto.FirstName;
				passenger.LastName = passengerDto.LastName;
				passenger.Age = passengerDto.Age;
				passenger.Gender = passengerDto.Gender;
				passenger.PhoneNumber = passengerDto.PhoneNumber;
				passenger.AllocatedSeat = passengerDto.AllocatedSeat;
				passenger.UserId = passengerDto.UserId;
				passenger.FlightBookingId = passengerDto.FlightBookingId;

				// Map Domain model to Dto
				passengerDto = new PassengerDto
				{
					PassengerId = passenger.PassengerId,
					FirstName = passenger.FirstName,
					LastName = passenger.LastName,
					Age = passenger.Age,
					Gender = passenger.Gender,
					PhoneNumber = passenger.PhoneNumber,
					AllocatedSeat = passenger.AllocatedSeat,
					UserId = passenger.UserId,
					FlightBookingId = passenger.FlightBookingId
				};
				return Ok(passengerDto);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while updating the passenger.");
			}
		}

		//Delete Passenger
		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeleteAsync([FromRoute] int id)
		{
			try
			{
				var passenger = await passengerRepository.DeleteAsync(id);
				if (passenger == null)
				{
					return NotFound();
				}

				// Map Domain model to Dto
				var passengerDto = new PassengerDto
				{
					PassengerId = passenger.PassengerId,
					FirstName = passenger.FirstName,
					LastName = passenger.LastName,
					Age = passenger.Age,
					Gender = passenger.Gender,
					PhoneNumber = passenger.PhoneNumber,
					AllocatedSeat = passenger.AllocatedSeat,
					UserId = passenger.UserId,
					FlightBookingId = passenger.FlightBookingId
				};

				return Ok(passengerDto);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while deleting the passenger.");
			}
		}



	}
}
