using FlightBookingSystem.Data;
using FlightBookingSystem.Models.Domain;
using FlightBookingSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.Repositories
{
    public class FlightRepository : IFlight
	{
		private readonly FlightDbContext dbContext;

		public FlightRepository(FlightDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

		//Get All Flights
		public async Task<List<Flight>> GetAllAsync()
		{
			return await dbContext.Flights.ToListAsync();
		}

		//Get Flight By Id
		public async Task<Flight?> GetByIdAsync(int id)
		{
			return await dbContext.Flights.FirstOrDefaultAsync(m => m.FlightId == id);
		}

		//Get Flight By Name
		public async Task<List<Flight>> GetByNameAsync(string name)
		{
			var flightName = await dbContext.Flights.Where(m => m.FlightName == name).ToListAsync();
			return flightName;
		}

		//Get Flight By City Names
		public async Task<List<Flight>> GetByCitiesAsync(string DepartureCity, string ArrivalCity, DateTime DepartureDateTime)
		{
			var flight = await dbContext.Flights.Where(m => m.DepartureCity == DepartureCity && m.ArrivalCity == ArrivalCity && m.DepartureDateTime == DepartureDateTime).ToListAsync();
			return flight;
		}


		// Create Flight 
		public async Task<Flight> CreateAsync(Flight flight)
		{
			await dbContext.Flights.AddAsync(flight);
			await dbContext.SaveChangesAsync();
			return flight;
		}

		//Update Flight details
		public async Task<Flight?> UpdateAsync(int id, Flight flight)
		{
			var flightexist = await dbContext.Flights.FirstOrDefaultAsync(m => m.FlightId == id);
			if (flightexist == null)
			{
				return null;
			}
			flightexist.FlightName = flight.FlightName;
			flightexist.FlightNumber = flight.FlightNumber;
			flightexist.DepartureDateTime = flight.DepartureDateTime;
			flightexist.ArrivalDateTime = flight.ArrivalDateTime;
			flightexist.DepartureCity = flight.DepartureCity;
			flightexist.ArrivalCity = flight.ArrivalCity;
			flightexist.BasePrice = flight.BasePrice;

			await dbContext.SaveChangesAsync();

			return flightexist;
		}

		// Delete Flight Details
		public async Task<Flight?> DeleteAsync(int id)
		{
			var flightexist = await dbContext.Flights.FirstOrDefaultAsync(m => m.FlightId == id);
			if (flightexist == null)
			{
				return null;
			}

			dbContext.Flights.Remove(flightexist);
			await dbContext.SaveChangesAsync();
			return flightexist;
		}

		
	}
}
