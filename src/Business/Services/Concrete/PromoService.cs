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
public class PromoService : IPromoService
{
    private readonly IUnitOfWork _unitOfWork;
    IRepository<Promo> _promoRepository;
    private readonly IMapper _mapper;

    public PromoService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _promoRepository = _unitOfWork.Repository<Promo>();
        _mapper = mapper;
    }


    public async Task<List<PromoDTO>> GetAllAsync(
        Expression<Func<Promo, bool>>? expression = null,
        params Expression<Func<Promo, object>>[] includes)
    {
        var Promos = await _promoRepository.GetAllAsync(expression, includes);
        var dtos = _mapper.Map<List<PromoDTO>>(Promos);
        return dtos;
    }

    public async Task<List<PromoDTO>> GetAllPaginatedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<Promo, bool>>? expression = null,
        params Expression<Func<Promo, object>>[] includes)
    {
        var Promos = await _promoRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
        var dtos = _mapper.Map<List<PromoDTO>>(Promos);
        return dtos;
    }

    public async Task<PromoDTO?> GetAsync(
        Expression<Func<Promo, bool>>? expression = null,
        params Expression<Func<Promo, object>>[] includes)
    {
        var Promo = await _promoRepository.GetAsync(expression, includes);
        var dto = _mapper.Map<PromoDTO>(Promo);
        return dto;
    }

    public async Task Add(PromoDTO PromoDto)
    {
        var Promo = _mapper.Map<Promo>(PromoDto);
        await _promoRepository.Create(Promo);
    }

    public async Task Create(PromoDTO PromoDto)
    {
        var Promo = _mapper.Map<Promo>(PromoDto);
        await _promoRepository.Create(Promo);
        await SaveChangesAsync();
        _mapper.Map(Promo, PromoDto);
    }

    public void Update(PromoDTO PromoDto)
    {
        var Promo = _mapper.Map<Promo>(PromoDto);
        _promoRepository.Update(Promo);
    }

    public void Remove(PromoDTO PromoDto)
    {
        var Promo = _mapper.Map<Promo>(PromoDto);
        _promoRepository.Remove(Promo);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _promoRepository.SaveChangesAsync(cancellationToken);
    }
}
