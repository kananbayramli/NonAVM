using AutoMapper;
using ECommerse.Business.DTO_s;
using ECommerse.Business.Services.Abstract;
using ECommerse.Core.Entities;
using ECommerse.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse.Business.Services.Concrete;
public class PaymentService : IPaymentService
{
    private readonly IUnitOfWork _unitOfWork;
    IRepository<Payment> _paymentRepository;
    private readonly IMapper _mapper;

    public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _paymentRepository = _unitOfWork.Repository<Payment>();
        _mapper = mapper;
    }


    public async Task<List<PaymentDTO>> GetAllAsync(
        Expression<Func<Payment, bool>>? expression = null,
        params Expression<Func<Payment, object>>[] includes)
    {
        var Payments = await _paymentRepository.GetAllAsync(expression, includes);
        var dtos = _mapper.Map<List<PaymentDTO>>(Payments);
        return dtos;
    }

    public async Task<List<PaymentDTO>> GetAllPaginatedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<Payment, bool>>? expression = null,
        params Expression<Func<Payment, object>>[] includes)
    {
        var Payments = await _paymentRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
        var dtos = _mapper.Map<List<PaymentDTO>>(Payments);
        return dtos;
    }

    public async Task<PaymentDTO?> GetAsync(
        Expression<Func<Payment, bool>>? expression = null,
        params Expression<Func<Payment, object>>[] includes)
    {
        var Payment = await _paymentRepository.GetAsync(expression, includes);
        var dto = _mapper.Map<PaymentDTO>(Payment);
        return dto;
    }

    public async Task Create(PaymentDTO PaymentDto)
    {
        var Payment = _mapper.Map<Payment>(PaymentDto);
        await _paymentRepository.Create(Payment);
    }

    public void Update(PaymentDTO PaymentDto)
    {
        var Payment = _mapper.Map<Payment>(PaymentDto);
        _paymentRepository.Update(Payment);
    }

    public void Remove(PaymentDTO PaymentDto)
    {
        var Payment = _mapper.Map<Payment>(PaymentDto);
        _paymentRepository.Remove(Payment);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _paymentRepository.SaveChangesAsync(cancellationToken);
    }
}
