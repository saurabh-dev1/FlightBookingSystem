using FlightBookingSystem.Data;
using FlightBookingSystem.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminController : ControllerBase
	{
		private readonly FlightDbContext flightDbContext;
        public AdminController(FlightDbContext flightDbContext)
        {
            this.flightDbContext = flightDbContext;
        }

		//Get All Admins
        [HttpGet]
		public IActionResult GetAll()
		{
			var admins = flightDbContext.Admins.ToList();
			return Ok(admins);
		}

		// Get Single Admin
		[HttpGet]
		[Route("{id}")]
		public IActionResult GetById([FromRoute] int id)
		{
			var admin = flightDbContext.Admins.Where(x => x.AdminId == id).FirstOrDefault();
			if(admin == null)
			{
				return NotFound();
			}

			return Ok(admin);
		}

		// Create Admin
		[HttpPost]
		public IActionResult Create([FromBody] Admin admin)
		{
			flightDbContext.Admins.Add(admin);
			flightDbContext.SaveChanges();
			return Ok(admin);
		}


	}
}
