using FlightBookingSystem.Models.Domain;
using FlightBookingSystem.Models.DTOs;
using FlightBookingSystem.Repositories;
using FlightBookingSystem.Repositories.Interfaces;
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

		public PassengerController(IPassenger passengerRepository)
		{
			this.passengerRepository = passengerRepository;
		}

		// Get All Passengers
		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			var passengers = await passengerRepository.GetAllAsync();
			//Map Domain model to Dto

			var passengerDto = new List<PassengerDto>();
			foreach(var passenger in passengers)
			{
				passengerDto.Add(new PassengerDto()
				{
					PassengerId = passenger.PassengerId,
					FirstName = passenger.FirstName,
					LastName = passenger.LastName,
					Age = passenger.Age,
					Gender = passenger.Gender,
					PhoneNumber = passenger.PhoneNumber,
					UserId = passenger.UserId
				});
			}

			return Ok(passengerDto);
		}

		//Create Passenger
		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] PassengerDto passengerDto)
		{
			//Map Dto to Domain model
			var passenger = new Passenger
			{
				PassengerId = passengerDto.PassengerId,
				FirstName = passengerDto.FirstName,
				LastName = passengerDto.LastName,
				Age = passengerDto.Age,
				Gender = passengerDto.Gender,
				PhoneNumber = passengerDto.PhoneNumber,
				UserId = passengerDto.UserId
			};

			await passengerRepository.CreateAsync(passenger);
			//Map Domain model back to Dto
			passengerDto = new PassengerDto
			{
				PassengerId = passenger.PassengerId,
				FirstName = passenger.FirstName,
				LastName = passenger.LastName,
				Age = passenger.Age,
				Gender = passenger.Gender,
				PhoneNumber = passenger.PhoneNumber,
				UserId = passenger.UserId
			};
			return Ok(passengerDto);
		}

		//Get Passenger By id
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
		{
			var passenger = await passengerRepository.GetByIdAsync(id);
			if(passenger == null)
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
				UserId = passenger.UserId
			};

			return Ok(passengerDto);

		}

		//Get Passenger By User Id
		[HttpGet]
		[Route("User/{id}")]
		public async Task<IActionResult> GetByUserIdAsync([FromRoute] int id)
		{
			var passengers =await passengerRepository.GetByUserIdAsync(id);
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
					UserId = passenger.UserId
				});
			}

			if(passengers.Count == 0)
			{
				return NotFound();
			}
			else if(passengers.Count == 1)
			{
				return Ok(passengerDto[0]);
			}
			return Ok(passengerDto);
		}

		//Update Passenger
		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] PassengerDto passengerDto)
		{
			//Map Dto to Domain model
			var passenger = new Passenger()
			{
				PassengerId = passengerDto.PassengerId,
				FirstName = passengerDto.FirstName,
				LastName = passengerDto.LastName,
				Age = passengerDto.Age,
				Gender = passengerDto.Gender,
				PhoneNumber = passengerDto.PhoneNumber,
				UserId = passengerDto.UserId
			};

			//Check if booking exist
			passenger = await passengerRepository.UpdateAsync(id, passenger);
			if (passenger == null)
			{
				return NotFound();
			}
			// map Dto to Domain model
				passenger.PassengerId = passengerDto.PassengerId;
				passenger.FirstName = passengerDto.FirstName;
				passenger.LastName = passengerDto.LastName;
				passenger.Age = passengerDto.Age;
				passenger.Gender = passengerDto.Gender;
				passenger.PhoneNumber = passengerDto.PhoneNumber;
				passenger.UserId = passengerDto.UserId;

			//Map Domain model to Dto
			passengerDto = new PassengerDto
			{
				PassengerId = passenger.PassengerId,
				FirstName = passenger.FirstName,
				LastName = passenger.LastName,
				Age = passenger.Age,
				Gender = passenger.Gender,
				PhoneNumber = passenger.PhoneNumber,
				UserId = passenger.UserId
			};
			return Ok(passengerDto);
		}

		//Delete Passenger
		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeleteAsync([FromRoute] int id)
		{
			var passenger = await passengerRepository.DeleteAsync(id);
			if(passenger == null)
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
				UserId = passenger.UserId
			};

			return Ok(passengerDto);
		}


    }
}
