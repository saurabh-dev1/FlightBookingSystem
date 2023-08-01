using FlightBookingSystem.Models.Domain;
using FlightBookingSystem.Models.DTOs;
using FlightBookingSystem.Repositories;
using FlightBookingSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FlightBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FlightBookingController : ControllerBase
	{
		private readonly IFlightBooking flightBookingRepository;
		private readonly IUser users;
		private readonly IFlight flights;

		public FlightBookingController(IFlightBooking flightBooking, IUser users, IFlight flights)
        {
			this.flightBookingRepository = flightBooking;
			this.users = users;
			this.flights = flights;
		}


		// Get All Bookings
		[HttpGet]

		public async Task<IActionResult> GetAll()
		{
			try
			{
				var booking = await flightBookingRepository.GetAllAsync();

				// Map Domain Model To DTO
				var bookingDto = new List<FlightBookingDto>();
				foreach (var flightBooking in booking)
				{
					bookingDto.Add(new FlightBookingDto()
					{
						FlightBookingId = flightBooking.FlightBookingId,
						DepartureCity = flightBooking.DepartureCity,
						ArrivalCity = flightBooking.ArrivalCity,
						DepartureDateTime = flightBooking.DepartureDateTime,
						ArrivalDateTime = flightBooking.ArrivalDateTime,
						FlightId = flightBooking.FlightId,
						UserId = flightBooking.UserId,
					});
				}

				return Ok(bookingDto);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while fetching flight bookings.");
			}
		}


		// Get Booking By id
		[HttpGet]
		[Route("{id}")]

		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			try
			{
				var booking = await flightBookingRepository.GetByIdAsync(id);
				if (booking == null)
				{
					return NotFound();
				}

				// Map Domain model to Dto
				var bookingDto = new FlightBookingDto()
				{
					FlightBookingId = booking.FlightBookingId,
					DepartureCity = booking.DepartureCity,
					ArrivalCity = booking.ArrivalCity,
					DepartureDateTime = booking.DepartureDateTime,
					ArrivalDateTime = booking.ArrivalDateTime,
					FlightId = booking.FlightId,
					UserId = booking.UserId
				};

				return Ok(bookingDto);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while fetching the flight booking.");
			}
		}

		//Create Bookings

		[HttpPost("Add")]

		public async Task<IActionResult> CreateBooking(CreateFlightBookingDto flightBookingDto)
		{
			try
			{
				// Map DTO to Domain model
				var booking = new FlightBooking
				{
					DepartureCity = flightBookingDto.DepartureCity,
					ArrivalCity = flightBookingDto.ArrivalCity,
					DepartureDateTime = flightBookingDto.DepartureDateTime,
					ArrivalDateTime = flightBookingDto.ArrivalDateTime,
					FlightId = flightBookingDto.FlightId,
					UserId = flightBookingDto.UserId
				};

				await flightBookingRepository.CreateAsync(booking);

				// Map Domain model to Dto
				var flightBookingDto1 = new FlightBookingDto
				{
					FlightBookingId = booking.FlightBookingId,
					DepartureCity = booking.DepartureCity,
					ArrivalCity = booking.ArrivalCity,
					DepartureDateTime = booking.DepartureDateTime,
					ArrivalDateTime = booking.ArrivalDateTime,
					FlightId = booking.FlightId,
					UserId = booking.UserId
				};

				return Ok(flightBookingDto1);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while creating the flight booking.");
			}
		}


		//Update Bookings

		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> UpdateBookings([FromRoute] int id, [FromBody] FlightBookingDto flightBookingDto)
		{
			try
			{
				// Map DTO to Domain Models
				var booking = new FlightBooking
				{
					FlightBookingId = flightBookingDto.FlightBookingId,
					DepartureCity = flightBookingDto.DepartureCity,
					ArrivalCity = flightBookingDto.ArrivalCity,
					DepartureDateTime = flightBookingDto.DepartureDateTime,
					ArrivalDateTime = flightBookingDto.ArrivalDateTime,
					FlightId = flightBookingDto.FlightId,
					UserId = flightBookingDto.UserId
				};

				// Check if booking exists and update
				booking = await flightBookingRepository.UpdateAsync(id, booking);
				if (booking == null)
				{
					return NotFound();
				}

				// Map DomainModel to Dto
				flightBookingDto = new FlightBookingDto
				{
					FlightBookingId = booking.FlightBookingId,
					DepartureCity = booking.DepartureCity,
					ArrivalCity = booking.ArrivalCity,
					DepartureDateTime = booking.DepartureDateTime,
					ArrivalDateTime = booking.ArrivalDateTime,
					FlightId = booking.FlightId,
					UserId = booking.UserId
				};

				return Ok(flightBookingDto);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while updating the flight booking.");
			}
		}


		//Delete Bookings
		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeleteBooking([FromRoute] int id)
		{
			try
			{
				var booking = await flightBookingRepository.DeleteAsync(id);
				if (booking == null)
				{
					return NotFound();
				}

				// Convert domain model to dto
				var bookingDto = new FlightBookingDto
				{
					FlightBookingId = booking.FlightBookingId,
					DepartureCity = booking.DepartureCity,
					ArrivalCity = booking.ArrivalCity,
					DepartureDateTime = booking.DepartureDateTime,
					ArrivalDateTime = booking.ArrivalDateTime,
					FlightId = booking.FlightId,
					UserId = booking.UserId
				};

				return Ok(bookingDto);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while deleting the flight booking.");
			}
		}


		//Get Bookings By User Id
		[HttpGet]
		[Route("User/{id}")]
		public async Task<IActionResult> GetByUserId([FromRoute] int id)
		{
			try
			{
				var bookings = await flightBookingRepository.GetByUserIdAsync(id);
				var bookingDto = new List<FlightBookingDto>();
				foreach (var booking in bookings)
				{
					// Map Domain model to Dto
					bookingDto.Add(new FlightBookingDto()
					{
						FlightBookingId = booking.FlightBookingId,
						DepartureCity = booking.DepartureCity,
						ArrivalCity = booking.ArrivalCity,
						DepartureDateTime = booking.DepartureDateTime,
						ArrivalDateTime = booking.ArrivalDateTime,
						FlightId = booking.FlightId,
						UserId = booking.UserId
					});
				}

				if (bookings.Count == 0)
				{
					return NotFound();
				}
				else if (bookings.Count == 1)
				{
					return Ok(bookingDto[0]);
				}

				return Ok(bookingDto);
			}
			catch (Exception ex)
			{
				return StatusCode(500, "An error occurred while fetching flight bookings by user ID.");
			}
		}



		// get bookings by user and flight id
		[HttpGet]
		[Route("{userId}/{flightId}")]
		public async Task<IActionResult> GetByUserFlightId([FromRoute] int userId, [FromRoute] int flightId)
		{
			try
			{
				var bookings = await flightBookingRepository.GetByUserAndFlightId(userId, flightId);
				var bookingDto = new List<FlightBookingDto>();

				foreach (var booking in bookings)
				{
					// Map Domain model to Dto
					bookingDto.Add(new FlightBookingDto()
					{
						FlightBookingId = booking.FlightBookingId,
						DepartureCity = booking.DepartureCity,
						ArrivalCity = booking.ArrivalCity,
						DepartureDateTime = booking.DepartureDateTime,
						ArrivalDateTime = booking.ArrivalDateTime,
						FlightId = booking.FlightId,
						UserId = booking.UserId
					});
				}

				if (bookings.Count == 0)
				{
					return NotFound();
				}
				else if (bookings.Count == 1)
				{
					return Ok(bookingDto[0]);
				}

				return Ok(bookingDto);
			}
			catch (Exception ex)
			{
				return StatusCode(500, "An error occurred while fetching flight bookings by user ID and flight ID.");
			}
		}

	}
}
