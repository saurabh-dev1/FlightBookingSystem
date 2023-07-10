using FlightBookingSystem.Models.DTOs;
using FlightBookingSystem.Repositories.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace FlightBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmailController : ControllerBase
	{
		private readonly IEmail emailRepository;

        public EmailController(IEmail emailRepository)
        {
            this.emailRepository = emailRepository;	
        }

        [HttpPost]

		public IActionResult SendMail(EmailDto request)
		{
			emailRepository.SendEmail(request);
			return Ok();
		}
	}
}
