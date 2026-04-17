using Microsoft.EntityFrameworkCore;
using webApi.Data;
using PaymentEntity = webApi.Features.Payment.Models.Payment;

namespace webApi.Features.Payment.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PaymentEntity>> GetAllPaymentAsync()
        {
            return await _context.Payment.ToListAsync();
        }

        public async Task<PaymentEntity?> GetPaymentByIdAsync(int id)
        {
            return await _context.Payment.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PaymentEntity> CreatePaymentAsync(PaymentEntity payment)
        {
            _context.Payment.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<PaymentEntity> UpdatePaymentAsync(PaymentEntity payment)
        {
            _context.Payment.Update(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task DeletePaymentAsync(PaymentEntity payment)
        {
            _context.Payment.Remove(payment);
            await _context.SaveChangesAsync();
        }
    }
}
