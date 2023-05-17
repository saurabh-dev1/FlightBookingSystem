using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.Data
{
	public class FlightAuthDbContext : IdentityDbContext
	{
		public FlightAuthDbContext(DbContextOptions<FlightAuthDbContext> options) : base(options)
		{
		}
		   protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);


			var userId = "15";
			var adminId = "14";

			var roles = new List<IdentityRole>
			{
				new IdentityRole
				{
					Id = userId,
					ConcurrencyStamp = userId,
					Name = "User",
					NormalizedName = "User".ToUpper()

				},
				new IdentityRole
				{
					Id = adminId,
					ConcurrencyStamp = adminId,
					Name = "Admin",
					NormalizedName = "Admin".ToUpper()

				}
			};

			builder.Entity<IdentityRole>().HasData(roles);
		}
	}
    
}
