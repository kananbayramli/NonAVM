using AutoMapper;
using ECommerse.Business.DTO_s;
using ECommerse.Business.Services.Abstract;
using ECommerse.Core.Entities;
using ECommerse.DataAccess.Repositories.Abstract;
using System.Linq.Expressions;
namespace ECommerse.Business.Services.Concrete;

public class BrandService : IScoppedLifetime, IBrandService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<Brand> _brandRepository;
    private readonly IMapper _mapper;
    public BrandService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _brandRepository = _unitOfWork.Repository<Brand>();
    }


    public async Task Create(BrandDTO storeDto)
    {
        var store = _mapper.Map<Brand>(storeDto);
        await _brandRepository.Create(store);
    }
    public async Task<List<BrandDTO>> GetAllAsync(Expression<Func<Brand, bool>>? expression = null, params Expression<Func<Brand, object>>[] includes)
    {
        var stores = await _brandRepository.GetAllAsync(expression, includes);
        var dtos = _mapper.Map<List<BrandDTO>>(stores);
        return dtos;
    }
    public async Task<List<BrandDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<Brand, bool>>? expression = null, params Expression<Func<Brand, object>>[] includes)
    {
        var stores = await _brandRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
        var dtos = _mapper.Map<List<BrandDTO>>(stores);
        return dtos;
    }
    public async Task<BrandDTO?> GetAsync(Expression<Func<Brand, bool>>? expression = null, params Expression<Func<Brand, object>>[] includes)
    {
        var store = await _brandRepository.GetAsync(expression, includes);
        var dto = _mapper.Map<BrandDTO>(store);
        return dto;
    }
    public void Remove(BrandDTO storeDto)
    {
        var store = _mapper.Map<Brand>(storeDto);
        _brandRepository.Remove(store);
    }
    public void Update(BrandDTO storeDto)
    {
        var store = _mapper.Map<Brand>(storeDto);
        _brandRepository.Update(store);
    }
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _brandRepository.SaveChangesAsync(cancellationToken);
    }
}
