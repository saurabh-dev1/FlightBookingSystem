using FlightBookingSystem.Data;
using Microsoft.AspNetCore.Http;
using FlightBookingSystem.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlightBookingSystem.Repositories;

namespace FlightBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FlightController : ControllerBase
	{
		
		private readonly IFlightRepository flightRepository;

		public FlightController( IFlightRepository flightRepository)
		{
			
			this.flightRepository = flightRepository;
		}

		// Get All Flights
		[HttpGet]
		public async Task<IActionResult> GetAllFlight()
		{
			var flights = await flightRepository.GetAllAsync();
			return Ok(flights);
		}

		// Get Flight By Id and Name
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetFlight(int id)
		{
			var flight = await flightRepository.GetByIdAsync(id);
			if (flight == null)
			{
				return NotFound();
			}
			return Ok(flight);
		}


		// Create Flight Details
		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] Flight flight)
		{
			var result = await flightRepository.CreateAsync(flight);
			return Ok(result);
		}

		// Updating Flight Details

	}
}
