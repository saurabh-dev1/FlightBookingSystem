using FlightBookingSystem.Data;
using Microsoft.AspNetCore.Http;
using FlightBookingSystem.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlightBookingSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using FlightBookingSystem.Models.DTOs;
using System.Diagnostics;

namespace FlightBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class FlightController : ControllerBase
	{

		private readonly IFlight flightRepository;
		public FlightController(IFlight flightRepository)
		{

			this.flightRepository = flightRepository;
		}

		// Get All Flights
		[HttpGet]
		/*[Authorize(Roles = "User, Admin")]*/
		public async Task<IActionResult> GetAllFlight()
		{
			var flights = await flightRepository.GetAllAsync();

			// Map Domain model to DTO
			var flightDto = new List<FlightDto>();
			foreach (var flight in flights)
			{
				flightDto.Add(new FlightDto()
				{
					FlightId = flight.FlightId,
					FlightName = flight.FlightName,
					FlightNumber = flight.FlightNumber,
					DepartureCity = flight.DepartureCity,
					ArrivalCity = flight.ArrivalCity,
					DepartureDateTime = flight.DepartureDateTime,
					ArrivalDateTime = flight.ArrivalDateTime,
					BasePrice = flight.BasePrice,
					TotalSeats = flight.TotalSeats,
					AvailableSeats = flight.AvailableSeats
				});
			}

			return Ok(flightDto);
		}




		// Get Flight By Id
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetFlight([FromRoute] int id)
		{
			var flight = await flightRepository.GetByIdAsync(id);
			if (flight == null)
			{
				return NotFound();
			}

			var flightDto = new FlightDto
			{
				FlightId = flight.FlightId,
				FlightName = flight.FlightName,
				FlightNumber = flight.FlightNumber,
				DepartureCity = flight.DepartureCity,
				ArrivalCity = flight.ArrivalCity,
				DepartureDateTime = flight.DepartureDateTime,
				ArrivalDateTime = flight.ArrivalDateTime,
				BasePrice = flight.BasePrice,
				TotalSeats = flight.TotalSeats,
				AvailableSeats = flight.AvailableSeats
			};
			return Ok(flightDto);
		}




		// Get Flight By Name
		[HttpGet]
		[Route("GetFlightByName/{name}")]
		public async Task<IActionResult> GetFlightByName([FromRoute] string name)
		{
			var flight = await flightRepository.GetByNameAsync(name);

			var flightDto = new List<FlightDto>();
			foreach (var flights in flight)
			{
				flightDto.Add(new FlightDto()
				{
					FlightId = flights.FlightId,
					FlightName = flights.FlightName,
					FlightNumber = flights.FlightNumber,
					DepartureCity = flights.DepartureCity,
					ArrivalCity = flights.ArrivalCity,
					DepartureDateTime = flights.DepartureDateTime,
					ArrivalDateTime = flights.ArrivalDateTime,
					BasePrice = flights.BasePrice,
					TotalSeats = flights.TotalSeats,
					AvailableSeats = flights.AvailableSeats
				});
			}

			if (flight.Count == 0)
			{
				return NotFound();
			}

			else if (flight.Count == 1)
			{
				return Ok(flightDto[0]);
			}


			return Ok(flightDto);
		}




		// Get Flight by Cities and time
		[HttpGet]
		[Route("GetByCities/{departCity}/{arrivalCity}/{DepartureTime}")]
		public async Task<IActionResult> GetByCities([FromRoute] string departCity, [FromRoute] string arrivalCity, [FromRoute] DateTime DepartureTime)
		{
			var flight = await flightRepository.GetByCitiesAsync(departCity, arrivalCity, DepartureTime);

			var flightDto = new List<FlightDto>();
			foreach (var flights in flight)
			{
				flightDto.Add(new FlightDto()
				{
					FlightId = flights.FlightId,
					FlightName = flights.FlightName,
					FlightNumber = flights.FlightNumber,
					DepartureCity = flights.DepartureCity,
					ArrivalCity = flights.ArrivalCity,
					DepartureDateTime = flights.DepartureDateTime,
					ArrivalDateTime = flights.ArrivalDateTime,
					BasePrice = flights.BasePrice,
					TotalSeats = flights.TotalSeats,
					AvailableSeats = flights.AvailableSeats
				});
			}
			if (flight.Count == 0)
			{
				return NotFound();
			}
			else if (flight.Count == 1)
			{
				return Ok(flightDto[0]);
			}
			return Ok(flight);
		}



		// Create Flight Details
		[HttpPost("Add")]

		public async Task<IActionResult> Create([FromBody] CreateFlightDto flightDto)
		{
			// Map DTO to Domain model
			var flight = new Flight
			{

				FlightName = flightDto.FlightName,
				FlightNumber = flightDto.FlightNumber,
				DepartureCity = flightDto.DepartureCity,
				ArrivalCity = flightDto.ArrivalCity,
				DepartureDateTime = flightDto.DepartureDateTime,
				BasePrice = flightDto.BasePrice

			};

			await flightRepository.CreateAsync(flight);

			// Map Domain model to DTO
			flightDto = new CreateFlightDto
			{

				FlightName = flight.FlightName,
				FlightNumber = flight.FlightNumber,
				DepartureCity = flight.DepartureCity,
				ArrivalCity = flight.ArrivalCity,
				DepartureDateTime = flight.DepartureDateTime,
				BasePrice = flight.BasePrice

			};
			return Ok(flightDto);

		}



		// Updating Flight Details
		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] CreateFlightDto flightDto)
		{
			//Map DTO to Domain Models
			var flight = new Flight
			{

				FlightName = flightDto.FlightName,
				FlightNumber = flightDto.FlightNumber,
				DepartureCity = flightDto.DepartureCity,
				ArrivalCity = flightDto.ArrivalCity,
				DepartureDateTime = flightDto.DepartureDateTime,
				BasePrice = flightDto.BasePrice

			};

			// Check if flight exist
			flight = await flightRepository.UpdateAsync(id, flight);
			if (flight == null)
			{
				return NotFound();
			}

			//Map DTO to domain model

			flight.FlightName = flightDto.FlightName;
			flight.FlightNumber = flightDto.FlightNumber;
			flight.DepartureCity = flightDto.DepartureCity;
			flight.ArrivalCity = flightDto.ArrivalCity;
			flight.DepartureDateTime = flightDto.DepartureDateTime;
			flight.BasePrice = flightDto.BasePrice;


			// Convert Domain model to DTO
			flightDto = new CreateFlightDto
			{

				FlightName = flight.FlightName,
				FlightNumber = flight.FlightNumber,
				DepartureCity = flight.DepartureCity,
				ArrivalCity = flight.ArrivalCity,
				DepartureDateTime = flight.DepartureDateTime,
				BasePrice = flight.BasePrice,

			};

			return Ok(flightDto);
		}




		// Delete Flight
		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeleteAsync([FromRoute] int id)
		{

			var flight = await flightRepository.DeleteAsync(id);

			if (flight == null)
			{
				return NotFound();
			}
			// Convert Domain model to DTO
			var flightDto = new FlightDto
			{
				FlightId = flight.FlightId,
				FlightName = flight.FlightName,
				FlightNumber = flight.FlightNumber,
				DepartureCity = flight.DepartureCity,
				ArrivalCity = flight.ArrivalCity,
				DepartureDateTime = flight.DepartureDateTime,
				ArrivalDateTime = flight.ArrivalDateTime,
				BasePrice = flight.BasePrice,
				TotalSeats = flight.TotalSeats,
				AvailableSeats = flight.AvailableSeats
			};
			return Ok(flightDto);
		}
	}
}