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
public class TrackingService : ITrackingService
{
    private readonly IUnitOfWork _unitOfWork;
    IRepository<Tracking> _trackingRepository;
    private readonly IMapper _mapper;

    public TrackingService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _trackingRepository = _unitOfWork.Repository<Tracking>();
        _mapper = mapper;
    }


    public async Task<List<TrackingDTO>> GetAllAsync(
        Expression<Func<Tracking, bool>>? expression = null,
        params Expression<Func<Tracking, object>>[] includes)
    {
        var Trackings = await _trackingRepository.GetAllAsync(expression, includes);
        var dtos = _mapper.Map<List<TrackingDTO>>(Trackings);
        return dtos;
    }

    public async Task<List<TrackingDTO>> GetAllPaginatedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<Tracking, bool>>? expression = null,
        params Expression<Func<Tracking, object>>[] includes)
    {
        var Trackings = await _trackingRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
        var dtos = _mapper.Map<List<TrackingDTO>>(Trackings);
        return dtos;
    }

    public async Task<TrackingDTO?> GetAsync(
        Expression<Func<Tracking, bool>>? expression = null,
        params Expression<Func<Tracking, object>>[] includes)
    {
        var Tracking = await _trackingRepository.GetAsync(expression, includes);
        var dto = _mapper.Map<TrackingDTO>(Tracking);
        return dto;
    }

    public async Task Create(TrackingDTO TrackingDto)
    {
        var Tracking = _mapper.Map<Tracking>(TrackingDto);
        await _trackingRepository.Create(Tracking);
    }

    public void Update(TrackingDTO TrackingDto)
    {
        var Tracking = _mapper.Map<Tracking>(TrackingDto);
        _trackingRepository.Update(Tracking);
    }

    public void Remove(TrackingDTO TrackingDto)
    {
        var Tracking = _mapper.Map<Tracking>(TrackingDto);
        _trackingRepository.Remove(Tracking);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _trackingRepository.SaveChangesAsync(cancellationToken);
    }
}
