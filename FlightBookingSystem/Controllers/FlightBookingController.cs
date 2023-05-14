using FlightBookingSystem.Models.Domain;
using FlightBookingSystem.Models.DTOs;
using FlightBookingSystem.Repositories;
using FlightBookingSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FlightBookingController : ControllerBase
	{
		private readonly IFlightBooking flightBookingRepository;

		public FlightBookingController(IFlightBooking flightBooking)
        {
			this.flightBookingRepository = flightBooking;
		}


		// Get All Bookings
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var boooking = await flightBookingRepository.GetAllAsync();
			// Map Domain Model To DTO

			var bookingDto = new List<FlightBookingDto>();
			foreach (var flightBooking in boooking)
			{
				bookingDto.Add(new FlightBookingDto()
				{
					FlightBookingId = flightBooking.FlightBookingId,
					DepartureCity = flightBooking.DepartureCity,
					ArrivalCity = flightBooking.ArrivalCity,
					DepartureDateTime = flightBooking.DepartureDateTime,
					ArrivalDateTime = flightBooking.ArrivalDateTime,
					NoOfPassenger = flightBooking.NoOfPassenger,
				});
			}

			return Ok(bookingDto);
			
		}

		// Get Booking By id
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			var booking = await flightBookingRepository.GetByIdAsync(id);
			if (booking == null)
			{
				return NotFound();
			}

			//Map Domain model to Dto
			var bookingDto = new FlightBookingDto()
			{
				FlightBookingId = booking.FlightBookingId,
				DepartureCity = booking.DepartureCity,
				ArrivalCity = booking.ArrivalCity,
				DepartureDateTime = booking.DepartureDateTime,
				ArrivalDateTime = booking.ArrivalDateTime,
				NoOfPassenger = booking.NoOfPassenger,
			};
			return Ok(bookingDto);
		}

		//Create Bookings
		[HttpPost]
		public async Task<IActionResult> CreateBooking([FromBody] FlightBookingDto flightBookingDto)
		{
			// Map DTO to Domain model
			var booking = new FlightBooking
			{
				FlightBookingId = flightBookingDto.FlightBookingId,
				DepartureCity = flightBookingDto.DepartureCity,
				ArrivalCity = flightBookingDto.ArrivalCity,
				DepartureDateTime = flightBookingDto.DepartureDateTime,
				ArrivalDateTime = flightBookingDto.ArrivalDateTime,
				NoOfPassenger = flightBookingDto.NoOfPassenger,
			};

			await flightBookingRepository.CreateAsync(booking);

			//Map Domain model to Dto
			flightBookingDto = new FlightBookingDto
			{
				FlightBookingId = booking.FlightBookingId,
				DepartureCity = booking.DepartureCity,
				ArrivalCity = booking.ArrivalCity,
				DepartureDateTime = booking.DepartureDateTime,
				ArrivalDateTime = booking.ArrivalDateTime,
				NoOfPassenger = booking.NoOfPassenger,
			};

			return CreatedAtAction(nameof(GetById), new {id = booking.FlightBookingId}, flightBookingDto);

		}
	}
}
