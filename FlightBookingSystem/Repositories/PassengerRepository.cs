using FlightBookingSystem.Data;
using FlightBookingSystem.Models.Domain;
using FlightBookingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.Repositories
{
	public class PassengerRepository : IPassenger
	{
		private readonly FlightDbContext flightDbContext;

		public PassengerRepository(FlightDbContext flightDbContext)
        {
			this.flightDbContext = flightDbContext;
		}

		//Create Passenger
        public async Task<Passenger> CreateAsync(Passenger passenger)
		{
			await flightDbContext.Passengers.AddAsync(passenger);
			await flightDbContext.SaveChangesAsync();
			return passenger;
		}

		//Get All Passenger
		public async Task<List<Passenger>> GetAllAsync()
		{
			return await flightDbContext.Passengers.ToListAsync();
		}

		//Get Passenger By id
		public async Task<Passenger?> GetByIdAsync(int id)
		{
			return await flightDbContext.Passengers.FirstOrDefaultAsync(m=>m.PassengerId == id);
		}

		//Get Passeneger by User ID
		public async Task<List<Passenger>> GetByUserIdAsync(int id)
		{
			return await flightDbContext.Passengers.Where(m => m.UserId == id).ToListAsync();
		}

		//Update Passenger
		public async Task<Passenger?> UpdateAsync(int id, Passenger passenger)
		{
			var passengerExist = await flightDbContext.Passengers.FirstOrDefaultAsync(m=>m.PassengerId==id);
			if (passengerExist == null)
			{
				return null;
			}
			passengerExist.FirstName = passenger.FirstName;
			passengerExist.LastName = passenger.LastName;
			passengerExist.Age = passenger.Age;
			passengerExist.Gender = passenger.Gender;
			passengerExist.PhoneNumber = passenger.PhoneNumber;
			

			await flightDbContext.SaveChangesAsync();
			return passengerExist;
		}

		//Delete Passenger
		public async Task<Passenger?> DeleteAsync(int id)
		{
			var passengerExist = await flightDbContext.Passengers.FirstOrDefaultAsync(m => m.PassengerId == id);
			if (passengerExist == null)
			{
				return null;
			}
			flightDbContext.Passengers.Remove(passengerExist);
			await flightDbContext.SaveChangesAsync();
			return passengerExist;
		}
	}
}
