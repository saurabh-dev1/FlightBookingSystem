using FlightBookingSystem.Models.DTOs;
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
			var payments = await paymentReposiotry.GetAllAsync();
			var paymentDto = new List<PaymentDto>();
			foreach (var payment in payments)
			{
				paymentDto.Add(new PaymentDto() {
					PaymentId = payment.PaymentId,
					PayemntTime = payment.PayemntTime,
					PaymentMethod = payment.PaymentMethod,
					TotalPrice = payment.TotalPrice,
					PaymentStatus = payment.PaymentStatus

				});
			}
			return Ok(paymentDto);

		}

		// Get By id PaymentId
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetByIdAsync([FromRoute]int id)
		{
			var payment = await paymentReposiotry.GetByIdAsync(id);
			if(payment == null)
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

		//Get By Booking id
		[HttpGet]
		[Route("GetByBookingId/{id}")]
		public Task<IActionResult> GetByBookingId([FromRoute] int id)
		{

		}


    }
}
