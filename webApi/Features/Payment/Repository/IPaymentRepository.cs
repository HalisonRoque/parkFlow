using PaymentEntity = webApi.Features.Payment.Models.Payment;

namespace webApi.Features.Payment.Repository
{
    public interface IPaymentRepository
    {
        Task<List<PaymentEntity>> GetAllPaymentAsync();
        Task<PaymentEntity?> GetPaymentByIdAsync(int id);

        Task<PaymentEntity> CreatePaymentAsync(PaymentEntity payment);

        Task<PaymentEntity> UpdatePaymentAsync(PaymentEntity payment);

        Task DeletePaymentAsync(PaymentEntity payment);
    }
}
