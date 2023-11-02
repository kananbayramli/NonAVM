using AutoMapper;
using ECommerse.Business.DTO_s;
using ECommerse.Business.Services.Abstract;
using ECommerse.Core.Entities;
using ECommerse.DataAccess.Repositories.Abstract;
using System.Linq.Expressions;
namespace ECommerse.Business.Services.Concrete
{
    public class StoreService : IScoppedLifetime, IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        IRepository<Store> _storeRepository;
        private readonly IMapper _mapper;
        public StoreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _storeRepository = _unitOfWork.Repository<Store>();
        }


        public async Task Create(StoreDTO storeDto)
        {
            var store = _mapper.Map<Store>(storeDto);
            await _storeRepository.Create(store);
        }
        public async Task<List<StoreDTO>> GetAllAsync(Expression<Func<Store, bool>>? expression = null, params Expression<Func<Store, object>>[] includes)
        {
            var stores = await _storeRepository.GetAllAsync(expression, includes);
            var dtos = _mapper.Map<List<StoreDTO>>(stores);
            return dtos;
        }
        public async Task<List<StoreDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<Store, bool>>? expression = null, params Expression<Func<Store, object>>[] includes)
        {
            var stores = await _storeRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
            var dtos = _mapper.Map<List<StoreDTO>>(stores);
            return dtos;
        }
        public async Task<StoreDTO?> GetAsync(Expression<Func<Store, bool>>? expression = null, params Expression<Func<Store, object>>[] includes)
        {
            var store = await _storeRepository.GetAsync(expression, includes);
            var dto = _mapper.Map<StoreDTO>(store);
            return dto;
        }
        public void Remove(StoreDTO storeDto)
        {
            var store = _mapper.Map<Store>(storeDto);
            _storeRepository.Remove(store);
        }
        public void Update(StoreDTO storeDto)
        {
            var store = _mapper.Map<Store>(storeDto);
            _storeRepository.Update(store);
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _storeRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
