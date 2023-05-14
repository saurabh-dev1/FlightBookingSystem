using FlightBookingSystem.Data;
using FlightBookingSystem.Models.Domain;
using FlightBookingSystem.Models.DTOs;
using FlightBookingSystem.Repositories;
using FlightBookingSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminController : ControllerBase
	{
	
		

		public IAdmin AdminRepository { get; }

		public AdminController(IAdmin AdminRepository)
        {
            
			this.AdminRepository = AdminRepository;
		}

		//Get All Admins
        [HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var admins =  await AdminRepository.GetAllAsync();

			var adminsDto = new List<AdminDto>();
			foreach(var admin in admins)
			{
				adminsDto.Add(new AdminDto()
				{
					AdminId = admin.AdminId,
					Name = admin.Name,
					EmailAddress = admin.EmailAddress,
					Password = admin.Password
				});
			}

			return Ok(adminsDto);
		}

		// Get Single Admin by id
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			var admin = await AdminRepository.GetByIdAsync(id);
			if(admin == null)
			{
				return NotFound();
			}

			var adminDto = new AdminDto
			{
				AdminId = admin.AdminId,
				Name = admin.Name,
				EmailAddress = admin.EmailAddress,
				Password = admin.Password
			};

			return Ok(adminDto);
		}

		// Create Admin
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] AdminDto adminDto)
		{
			var admin = new Admin
			{
				AdminId = adminDto.AdminId,
				Name = adminDto.Name,
				EmailAddress = adminDto.EmailAddress,
				Password = adminDto.Password

			};

			await AdminRepository.CreateAsync(admin);
		
			
			return CreatedAtAction(nameof(GetById), new {id = admin.AdminId}, admin);
		}

		
	}
}
