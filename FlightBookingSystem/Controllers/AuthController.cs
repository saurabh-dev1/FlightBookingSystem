using FlightBookingSystem.Models.DTOs;
using FlightBookingSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserManager<IdentityUser> userManager;

		public IToken TokenRepository { get; }

		public AuthController(UserManager<IdentityUser> userManager, IToken tokenRepository)
        {
			this.userManager = userManager;
			TokenRepository = tokenRepository;
		}

		// For register
        [HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Register([FromBody] CreateUserDto userDto)
		{
			var identityUser = new IdentityUser
			{
				UserName = userDto.UserName,
				Email = userDto.EmailAddress,
				PasswordHash = userDto.Password,
				PhoneNumber = userDto.PhoneNo,
				
			};
			

				var identityResult = await userManager.CreateAsync(identityUser, userDto.Password);

				if (identityResult.Succeeded)
				{
					// Add roles to the user
					if (userDto.Roles.Any() && userDto.Roles != null)
					{
						identityResult = await userManager.AddToRolesAsync(identityUser, userDto.Roles);

						if (identityResult.Succeeded)
						{
							return Ok("User is Registered! Please login.");
						}
					}
				}
			
			
			return BadRequest();
		}


		// for login
		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
		{
			var user= await userManager.FindByNameAsync(loginDto.UserName);

			if(user != null)
			{
				var checkPassword = await userManager.CheckPasswordAsync(user, loginDto.Password);

				if (checkPassword)
				{
					//Get Roles for this user
					var roles = await userManager.GetRolesAsync(user);
					if(roles != null)
					{
						//Create token
						var jwtToken = TokenRepository.CreateJWTToken(user, roles.ToList());
						var response = new LoginResponseDto
						{
							JwtToken = jwtToken,
						};

						return Ok(response);
					}

				
				}
			}

			return BadRequest("UserName or Password is incorrect");
		}






	}
}
