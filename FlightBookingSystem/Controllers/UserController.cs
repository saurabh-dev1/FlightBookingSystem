using FlightBookingSystem.Models.Domain;
using FlightBookingSystem.Models.DTOs;
using FlightBookingSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace FlightBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUser userRepository;

		public UserController(IUser userRepository)
        {
			this.userRepository = userRepository;
		}

		//Get All Users
		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			var users = await userRepository.GetAllAsync();

			var userDto = new List<UserDto>();
			foreach(var user in users)
			{
				userDto.Add(new UserDto()
				{
					UserId = user.UserId,
					UserName = user.UserName,
					EmailAddress = user.EmailAddress,
					Password=user.Password,
					PhoneNo = user.PhoneNo
				});
			}

			return Ok(userDto);
		}

		//Get User By Id
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
		{
			var user = await userRepository.GetByIdAsync(id);
			if(user == null)
			{
				return NotFound();
			}
			// Map Domain Model to Dto
			var userDto = new UserDto
			{
				UserId = user.UserId,
				UserName = user.UserName,
				EmailAddress = user.EmailAddress,
				Password = user.Password,
				PhoneNo = user.PhoneNo
			};

			return Ok(userDto);
		}

		//Create User
		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody]  CreateUserDto userDto)
		{
			//map Dto to Domain model
			var user = new User
			{
				
				UserName = userDto.UserName,
				EmailAddress = userDto.EmailAddress,
				Password = userDto.Password,
				PhoneNo = userDto.PhoneNo
			};

			await userRepository.CreateAsync(user);

			//Map Domain modle to Dto
			userDto = new CreateUserDto
			{
				
				UserName = user.UserName,
				EmailAddress = user.EmailAddress,
				Password = user.Password,
				PhoneNo = user.PhoneNo
			};

			return Ok(userDto);
		}

		// Update User
		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UserDto userDto)
		{
			var user = new User
			{
				UserId = userDto.UserId,
				UserName = userDto.UserName,
				EmailAddress = userDto.EmailAddress,
				Password = userDto.Password,
				PhoneNo = userDto.PhoneNo
			};

			user = await userRepository.UpdateAsync(id, user);
			if(user == null)
			{
				return NotFound();
			}
			user.UserId = userDto.UserId;
			user.UserName = userDto.UserName;
			user.EmailAddress = userDto.EmailAddress;
			user.Password = userDto.Password;
			user.PhoneNo = user.PhoneNo;

			userDto = new UserDto
			{
				UserId = user.UserId,
				UserName = user.UserName,
				EmailAddress = user.EmailAddress,
				Password = user.Password
			};

			return Ok(userDto);
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeleteUserAsync([FromRoute] int id)
		{
			var user = await userRepository.DeleteAsync(id);
			if (user == null)
			{
				return NotFound();
			}

			var userDto = new UserDto
			{
				UserId = user.UserId,
				UserName = user.UserName,
				EmailAddress = user.EmailAddress,
				Password = user.Password,
				PhoneNo = user.PhoneNo
			};

			return Ok(userDto);
		}
		
    }
}
