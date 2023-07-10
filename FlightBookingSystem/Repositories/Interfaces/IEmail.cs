using FlightBookingSystem.Models.DTOs;

namespace FlightBookingSystem.Repositories.Interfaces
{
	public interface IEmail
	{
		void SendEmail(EmailDto request);
	}
}
