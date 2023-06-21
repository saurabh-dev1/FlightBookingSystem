using FlightBookingSystem.Data;
using FlightBookingSystem.Models.Domain;
using FlightBookingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.Repositories
{
	public class PaymentRepository : IPayment
	{
		private readonly FlightDbContext dbContext;

		public PaymentRepository(FlightDbContext dbContext)
        {
			this.dbContext = dbContext;
		}
        public async Task<Payment> CreateAsync(Payment payment)
		{
			await dbContext.Payments.AddAsync(payment);
			await dbContext.SaveChangesAsync();
			return payment;
		}

		public async Task<Payment?> DeleteAsync(int id)
		{
			var paymentExist = await dbContext.Payments.FirstOrDefaultAsync(m => m.PaymentId == id);
			if (paymentExist == null)
			{
				return null;
			}
			dbContext.Payments.Remove(paymentExist);
			await dbContext.SaveChangesAsync();
			return paymentExist;
		}
	

		public async Task<List<Payment>> GetAllAsync()
		{
			return await dbContext.Payments.ToListAsync();
		}

		public async Task<List<Payment>> GetByBookingIdAsync(int id)
		{
			return await dbContext.Payments.Where(m=>m.FlightBookingId == id).ToListAsync();
		}

		public async Task<Payment?> GetByIdAsync(int id)
		{
			return await dbContext.Payments.FirstOrDefaultAsync(m => m.PaymentId == id);
		}
	}
}
