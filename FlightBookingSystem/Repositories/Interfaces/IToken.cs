using Microsoft.AspNetCore.Identity;

namespace FlightBookingSystem.Repositories.Interfaces
{
	public interface IToken
	{
		string CreateJWTToken(IdentityUser user, List<string> roles);
	}
}
