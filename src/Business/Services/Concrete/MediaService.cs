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
public class MediaService : IMediaService
{
    private readonly IUnitOfWork _unitOfWork;
    IRepository<Media> _mediaRepository;
    private readonly IMapper _mapper;

    public MediaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mediaRepository = _unitOfWork.Repository<Media>();
        _mapper = mapper;
    }


    public async Task<List<MediaDTO>> GetAllAsync(
        Expression<Func<Media, bool>>? expression = null,
        params Expression<Func<Media, object>>[] includes)
    {
        var Medias = await _mediaRepository.GetAllAsync(expression, includes);
        var dtos = _mapper.Map<List<MediaDTO>>(Medias);
        return dtos;
    }

    public async Task<List<MediaDTO>> GetAllPaginatedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<Media, bool>>? expression = null,
        params Expression<Func<Media, object>>[] includes)
    {
        var Medias = await _mediaRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
        var dtos = _mapper.Map<List<MediaDTO>>(Medias);
        return dtos;
    }

    public async Task<MediaDTO?> GetAsync(
        Expression<Func<Media, bool>>? expression = null,
        params Expression<Func<Media, object>>[] includes)
    {
        var Media = await _mediaRepository.GetAsync(expression, includes);
        var dto = _mapper.Map<MediaDTO>(Media);
        return dto;
    }

    public async Task Create(MediaDTO MediaDto)
    {
        var Media = _mapper.Map<Media>(MediaDto);
        await _mediaRepository.Create(Media);
    }

    public void Update(MediaDTO MediaDto)
    {
        var Media = _mapper.Map<Media>(MediaDto);
        _mediaRepository.Update(Media);
    }

    public void Remove(MediaDTO MediaDto)
    {
        var Media = _mapper.Map<Media>(MediaDto);
        _mediaRepository.Remove(Media);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _mediaRepository.SaveChangesAsync(cancellationToken);
    }
}
