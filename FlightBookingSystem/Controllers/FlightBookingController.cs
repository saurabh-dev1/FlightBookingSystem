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
					NoOfPassenger = flightBooking.NoOfPassenger,
					FlightId = flightBooking.FlightId,
					UserId = flightBooking.UserId,
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
				FlightId = booking.FlightId,
				UserId = booking.UserId
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
				FlightId = flightBookingDto.FlightId,
				UserId = flightBookingDto.UserId
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
				FlightId = booking.FlightId,
				UserId = booking.UserId
			};

			return Ok(flightBookingDto);

		}

		//Update Bookings

		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> UpdateBookings([FromRoute] int id ,[FromBody] FlightBookingDto flightBookingDto)
		{
			//Map DTO to Domain Models
			var booking = new FlightBooking
			{
				FlightBookingId = flightBookingDto.FlightBookingId,
				DepartureCity = flightBookingDto.DepartureCity,
				ArrivalCity = flightBookingDto.ArrivalCity,
				DepartureDateTime = flightBookingDto.DepartureDateTime,
				ArrivalDateTime = flightBookingDto.ArrivalDateTime,
				NoOfPassenger = flightBookingDto.NoOfPassenger,
				FlightId = flightBookingDto.FlightId,
				UserId = flightBookingDto.UserId
			};

			//Check if booking exist
			booking = await flightBookingRepository.UpdateAsync(id, booking);
			if (booking == null)
			{
				return NotFound();
			}

			//Map Dto to Domain Model
				booking.FlightBookingId = flightBookingDto.FlightBookingId;
				booking.DepartureCity = flightBookingDto.DepartureCity;
				booking.ArrivalCity = flightBookingDto.ArrivalCity;
				booking.DepartureDateTime = flightBookingDto.DepartureDateTime;
				booking.ArrivalDateTime = flightBookingDto.ArrivalDateTime;
				booking.NoOfPassenger = flightBookingDto.NoOfPassenger;
			booking.FlightId = flightBookingDto.FlightId;
			booking.UserId = flightBookingDto.UserId;

			//Map DomainModel to Dto
			flightBookingDto = new FlightBookingDto
			{
				FlightBookingId = booking.FlightBookingId,
				DepartureCity = booking.DepartureCity,
				ArrivalCity = booking.ArrivalCity,
				DepartureDateTime = booking.DepartureDateTime,
				ArrivalDateTime = booking.ArrivalDateTime,
				NoOfPassenger = booking.NoOfPassenger,
				FlightId = booking.FlightId,
				UserId = booking.UserId
			};

			return Ok(flightBookingDto);
		}

		//Delete Bookings
		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeleteBooking([FromRoute] int id)
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
				NoOfPassenger = booking.NoOfPassenger,
				FlightId = booking.FlightId,
				UserId = booking.UserId
			};

			return Ok(bookingDto);
		}

		//Get Bookings By User Id
		[HttpGet]
		[Route("User/{id}")]
		public async Task<IActionResult> GetByUserId([FromRoute] int id)
		{
			var bookings = await flightBookingRepository.GetByUserIdAsync(id);
			var bookingDto = new List<FlightBookingDto>();
			foreach (var booking in bookings)
			{
				//Map Domian model to Dto
				bookingDto.Add(new FlightBookingDto()
				{
					FlightBookingId = booking.FlightBookingId,
					DepartureCity = booking.DepartureCity,
					ArrivalCity = booking.ArrivalCity,
					DepartureDateTime = booking.DepartureDateTime,
					ArrivalDateTime = booking.ArrivalDateTime,
					NoOfPassenger = booking.NoOfPassenger,
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


	}
}
