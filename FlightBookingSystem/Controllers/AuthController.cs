using FlightBookingSystem.Data;
using FlightBookingSystem.Models.Domain;
using FlightBookingSystem.Models.DTOs;
using FlightBookingSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlightBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		
		private readonly FlightDbContext dbContext;

		

		public AuthController(FlightDbContext dbContext)
        {
			
			
			this.dbContext = dbContext;
		}

		// For register
        [HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Register([FromBody] CreateUserDto userDto )
		{
			var user = new User
			{

				UserName = userDto.UserName,
				EmailAddress = userDto.EmailAddress,
				Password = userDto.Password,
				PhoneNo = userDto.PhoneNo,
			
			};

			if (user == null)
				return BadRequest();

			//check username

			if (await CheckUserNameAsync(user.UserName))
				return BadRequest(new { Message = "Username Already Exist" });

			//check Email
			if (await CheckEmailAsync(user.EmailAddress))
				return BadRequest(new { Message = "Email Already Exist" });

			await dbContext.Users.AddAsync(user);
			await dbContext.SaveChangesAsync();

			userDto = new CreateUserDto
			{
				UserName = user.UserName,
				EmailAddress = user.EmailAddress,
				Password = user.Password,
				PhoneNo = user.PhoneNo,
				
			};

			return Ok(new
			{
				Message = "User Registered!"
			});

			
/*
			var identityUser = new IdentityUser
			{
				UserName = userDto.UserName,
				Email = userDto.EmailAddress,
				PasswordHash = userDto.Password,
				PhoneNumber = userDto.PhoneNo,
				
				
			};*/
			

				/*var identityResult = await userManager.CreateAsync(identityUser, userDto.Password);
			if (identityResult.Succeeded)
			{
				// Add roles to the user
				*//*if (userDto.Roles.Any() && userDto.Roles != null)
				{
					identityResult = await userManager.AddToRolesAsync(identityUser, userDto.Roles);

					if (identityResult.Succeeded)
					{
						return Ok("User is Registered! Please login.");
					}
				}*//*
				return Ok("User is Registered! Please login.");
			}


			return BadRequest("Not registered");*/

		}
		//check username
		private Task<bool> CheckUserNameAsync(string username)
		
			=> dbContext.Users.AnyAsync(m => m.UserName == username);

		//check Email
		private Task<bool> CheckEmailAsync(string email)

			=> dbContext.Users.AnyAsync(m => m.EmailAddress == email);



		// Create Token 
		private string CreateJwt(LoginRequestDto loginDto)
		{
			var jwtTokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes("kjdsfhvkjsdfhkjshfdkjvhjkdkjfklrt");
			var identity = new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.Role, loginDto.Roles),
				new Claim(ClaimTypes.Name, $"{loginDto.UserName}")
			});
			var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = identity,
				Expires = DateTime.Now.AddMinutes(30),
				SigningCredentials = credentials
			};
			var token = jwtTokenHandler.CreateToken(tokenDescriptor);
			return jwtTokenHandler.WriteToken(token);
		}


		// for login
		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
		{

			if (loginDto == null)
				return BadRequest();

			var user = await dbContext.Users
				.FirstOrDefaultAsync(m =>m.UserName == loginDto.UserName && m.Password == loginDto.Password);

			if(user==null)
				return NotFound(new {Message = "User not Found"});

			loginDto.Token = CreateJwt(loginDto);


			return Ok(new
			{
				Token = loginDto.Token,
				Message = user.Roles
				}); 







			/*var user= await userManager.FindByNameAsync(loginDto.UserName);

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
			

			return BadRequest("UserName or Password is incorrect");*/
		}






	}
}
