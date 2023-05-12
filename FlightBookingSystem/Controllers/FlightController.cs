using FlightBookingSystem.Data;
using Microsoft.AspNetCore.Http;
using FlightBookingSystem.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FlightController : ControllerBase
	{
		private readonly FlightDbContext flightDbContext;
		public FlightController(FlightDbContext flightDbContext)
		{
			this.flightDbContext = flightDbContext;
		}

		// Get All Flights
		[HttpGet]
		public async Task<IActionResult> GetAllFlight()
		{
			var flights = await flightDbContext.Flights.ToListAsync();
			return Ok(flights);
		}

		// Get Flight By Id and Name
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetFlight(int id)
		{
			var flight = await flightDbContext.Flights.Where(m => m.FlightId == id).FirstOrDefaultAsync();
			if (flight == null)
			{
				return NotFound();
			}
			return Ok(flight);
		}


		// Create Flight Details
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] Flight flight)
		{
			await flightDbContext.Flights.AddAsync(flight);
			await flightDbContext.SaveChangesAsync();
			return Ok(flight);
		}

		// Updating Flight Details

	}
}
