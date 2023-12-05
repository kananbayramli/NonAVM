using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract;
public interface IPaymentService
{
    Task Create(PaymentDTO PaymentDto);
    Task<List<PaymentDTO>> GetAllAsync(Expression<Func<Payment, bool>>? expression = null, params Expression<Func<Payment, object>>[] includes);
    Task<List<PaymentDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<Payment, bool>>? expression = null, params Expression<Func<Payment, object>>[] includes);
    Task<PaymentDTO?> GetAsync(Expression<Func<Payment, bool>>? expression = null, params Expression<Func<Payment, object>>[] includes);
    void Remove(PaymentDTO PaymentDto);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Update(PaymentDTO PaymentDto);
}