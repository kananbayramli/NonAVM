using AutoMapper;
using ECommerse.Business.DTO_s;
using ECommerse.Business.Services.Abstract;
using ECommerse.Core.Entities;
using ECommerse.DataAccess.Repositories.Abstract;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Concrete;
public class AddressService : IAddressService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<Address> _addressRepository;
    private readonly IMapper _mapper;
    public AddressService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _addressRepository = _unitOfWork.Repository<Address>();
    }


    public async Task Create(AddressDTO storeDto)
    {
        var store = _mapper.Map<Address>(storeDto);
        await _addressRepository.Create(store);
    }
    public async Task<List<AddressDTO>> GetAllAsync(Expression<Func<Address, bool>>? expression = null, params Expression<Func<Address, object>>[] includes)
    {
        var stores = await _addressRepository.GetAllAsync(expression, includes);
        var dtos = _mapper.Map<List<AddressDTO>>(stores);
        return dtos;
    }
    public async Task<List<AddressDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<Address, bool>>? expression = null, params Expression<Func<Address, object>>[] includes)
    {
        var stores = await _addressRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
        var dtos = _mapper.Map<List<AddressDTO>>(stores);
        return dtos;
    }
    public async Task<AddressDTO?> GetAsync(Expression<Func<Address, bool>>? expression = null, params Expression<Func<Address, object>>[] includes)
    {
        var store = await _addressRepository.GetAsync(expression, includes);
        var dto = _mapper.Map<AddressDTO>(store);
        return dto;
    }
    public void Remove(AddressDTO storeDto)
    {
        var store = _mapper.Map<Address>(storeDto);
        _addressRepository.Remove(store);
    }
    public void Update(AddressDTO storeDto)
    {
        var store = _mapper.Map<Address>(storeDto);
        _addressRepository.Update(store);
    }
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _addressRepository.SaveChangesAsync(cancellationToken);
    }
}
