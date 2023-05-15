using FlightBookingSystem.Models.Domain;
using FlightBookingSystem.Models.DTOs;
using FlightBookingSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SeatAllocationController : ControllerBase
	{
		private readonly ISeatAllocation seatRepository;

		public SeatAllocationController(ISeatAllocation seatRepository)
        {
			this.seatRepository = seatRepository;
		}

		//Get all seats
		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			var seats = await seatRepository.GetAllAsync();
			
				var seatDto = new List<SeatAllocationDto>();
			foreach (var seat in seats)
			{
				// Map Domain model to Dto
				seatDto.Add(new SeatAllocationDto()
				{
					SeatAllocationId = seat.SeatAllocationId,
					SeatAllocated = seat.SeatAllocated,
					SeatClass = seat.SeatClass,
					SeatNumber = seat.SeatNumber,
					PassengerId	= seat.PassengerId
				});
			}

			return Ok(seatDto);
		
		}

		//Get Seat By id
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
		{
			var seat = await seatRepository.GetByIdAsync(id);
			if(seat == null)
			{
				return NotFound();
			}
			//Map Domain model to Dto
			var seatDto = new SeatAllocationDto
			{
				SeatAllocationId = seat.SeatAllocationId,
				SeatAllocated = seat.SeatAllocated,
				SeatClass = seat.SeatClass,
				SeatNumber = seat.SeatNumber,
				PassengerId = seat.PassengerId
			};

			return Ok(seatDto);
		}

		//Get Seat by Passenger Id
		[HttpGet]
		[Route("Passenger/{id}")]
		public async Task<IActionResult> GetByPassengerAsync([FromRoute] int id)
		{
			var seats = await seatRepository.GetByPassengerIdAsync(id);

			var seatDto = new List<SeatAllocationDto>();
			foreach (var seat in seats)
			{
				// Map Domain model to Dto
				seatDto.Add(new SeatAllocationDto()
				{
					SeatAllocationId = seat.SeatAllocationId,
					SeatAllocated = seat.SeatAllocated,
					SeatClass = seat.SeatClass,
					SeatNumber = seat.SeatNumber,
					PassengerId = seat.PassengerId
				});
			}
			if (seats.Count == 0)
			{
				return NotFound();
			}
			else if (seats.Count == 1)
			{
				return Ok(seatDto[0]);
			}
			return Ok(seatDto);
		}

		//Create seats
		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] SeatAllocationDto seatDto)
		{
			//Map Dto to Domain Model
			var seat = new SeatAllocation
			{
				SeatAllocationId = seatDto.SeatAllocationId,
				SeatAllocated = seatDto.SeatAllocated,
				SeatClass = seatDto.SeatClass,
				SeatNumber = seatDto.SeatNumber,
				PassengerId = seatDto.PassengerId
			};

			await seatRepository.CreateAsync(seat);

			//Map Domain model back to Dto
			seatDto = new SeatAllocationDto
			{
				SeatAllocationId = seat.SeatAllocationId,
				SeatAllocated = seat.SeatAllocated,
				SeatClass = seat.SeatClass,
				SeatNumber = seat.SeatNumber,
				PassengerId = seat.PassengerId
			};

			return Ok(seatDto);
		}


	}
}
