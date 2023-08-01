using FlightBookingSystem.Models.Domain;
using FlightBookingSystem.Models.DTOs;
using FlightBookingSystem.Repositories;
using FlightBookingSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace FlightBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentController : ControllerBase
	{
		private readonly IPayment paymentReposiotry;

		public PaymentController(IPayment paymentReposiotry)
        {
			this.paymentReposiotry = paymentReposiotry;
		}

		//Get All Payment
		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			try
			{
				var payments = await paymentReposiotry.GetAllAsync();
				var paymentDto = new List<PaymentDto>();
				foreach (var payment in payments)
				{
					paymentDto.Add(new PaymentDto()
					{
						PaymentId = payment.PaymentId,
						PayemntTime = payment.PayemntTime,
						PaymentMethod = payment.PaymentMethod,
						TotalPrice = payment.TotalPrice,
						PaymentStatus = payment.PaymentStatus
					});
				}
				return Ok(paymentDto);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while fetching payments.");
			}
		}

		// Get By id PaymentId
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
		{
			try
			{
				var payment = await paymentReposiotry.GetByIdAsync(id);
				if (payment == null)
				{
					return NotFound();
				}
				var paymentDto = new PaymentDto
				{
					PaymentId = payment.PaymentId,
					PayemntTime = payment.PayemntTime,
					PaymentMethod = payment.PaymentMethod,
					TotalPrice = payment.TotalPrice,
					PaymentStatus = payment.PaymentStatus
				};
				return Ok(paymentDto);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while fetching the payment by ID.");
			}
		}


		//Get By Booking id
		[HttpGet]
		[Route("GetByBookingId/{id}")]
		public async Task<IActionResult> GetByBookingId([FromRoute] int id)
		{
			try
			{
				var payments = await paymentReposiotry.GetByBookingIdAsync(id);
				var paymentDto = new List<PaymentDto>();
				foreach (var payment in payments)
				{
					paymentDto.Add(new PaymentDto
					{
						PaymentId = payment.PaymentId,
						PayemntTime = payment.PayemntTime,
						PaymentMethod = payment.PaymentMethod,
						TotalPrice = payment.TotalPrice,
						PaymentStatus = payment.PaymentStatus
					});
				}

				return Ok(paymentDto);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while fetching payments by booking ID.");
			}
		}



		//Create Payment
		[HttpPost("Add")]
		public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentDto paymentDto)
		{
			try
			{
				// Map DTO to Domain model
				var payment = new Payment
				{
					PayemntTime = paymentDto.PayemntTime,
					PaymentMethod = paymentDto.PaymentMethod,
					PaymentStatus = paymentDto.PaymentStatus,
					TotalPrice = paymentDto.TotalPrice,
					FlightBookingId = paymentDto.FlightBookingId
				};

				await paymentReposiotry.CreateAsync(payment);

				// Map Domain model to Dto
				var paymentDto1 = new PaymentDto
				{
					PaymentId = payment.PaymentId,
					PayemntTime = payment.PayemntTime,
					PaymentMethod = payment.PaymentMethod,
					PaymentStatus = payment.PaymentStatus,
					TotalPrice = payment.TotalPrice,
					FlightBookingId = payment.FlightBookingId
				};

				return Ok(paymentDto1);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while creating the payment.");
			}
		}


		//Delete Payment
		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeletePayment([FromRoute] int id)
		{
			try
			{
				var payment = await paymentReposiotry.DeleteAsync(id);
				if (payment == null)
				{
					return NotFound();
				}

				// Convert domain model to dto
				var paymentDto = new PaymentDto
				{
					PaymentId = payment.PaymentId,
					PayemntTime = payment.PayemntTime,
					PaymentMethod = payment.PaymentMethod,
					PaymentStatus = payment.PaymentStatus,
					TotalPrice = payment.TotalPrice,
					FlightBookingId = payment.FlightBookingId
				};

				return Ok(paymentDto);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while deleting the payment.");
			}
		}


	}
}
