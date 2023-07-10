using FlightBookingSystem.Models.DTOs;
using FlightBookingSystem.Repositories.Interfaces;
using MimeKit;
using MailKit.Net.Smtp;

namespace FlightBookingSystem.Repositories
{
	public class EmailRepository : IEmail
	{
		private readonly IConfiguration _config;
		public EmailRepository(IConfiguration config)
		{
			_config = config;
		}


		public void SendEmail(EmailDto request)
		{
			var email = new MimeMessage();
			email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
			email.To.Add(MailboxAddress.Parse(request.email));
			email.Subject = request.subject;
			email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = request.body };

			using var smtp = new SmtpClient();
			smtp.Connect(_config.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
			smtp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
			smtp.Send(email);
			smtp.Disconnect(true);
		}
	}
}
