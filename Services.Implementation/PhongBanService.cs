using AutoMapper;
using Entities.DAOs;
using Entities.DTOs.CRUD;
using Entities.Exceptions;
using Entities.RequestFeatures;
using Services.Abstraction.IApplicationServices;
using Services.Abstraction.ILoggerServices;
using Services.Abstraction.IRepositoryServices;
using System.Security.Claims;


namespace Services.Implementation
{
    internal sealed class PhongBanService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) : IPhongBanService
    {
        private readonly IRepositoryManager _repository = repository;
        private readonly ILoggerManager _logger = logger;
        private readonly IMapper _mapper = mapper;

        
        public async Task<(IEnumerable<PhongBanDTO> phongBanDTO, MetaData metaData)> GetAllPhongBan(PhongBanParameters phongBanParameters, bool trackChanges)
        {
            var phongBansWithMetaData = await _repository.PhongBanRepository.GetAllPhongBan(phongBanParameters, trackChanges);

            return (phongBanDTO: _mapper.Map<IEnumerable<PhongBanDTO>>(phongBansWithMetaData), phongBansWithMetaData.metaData);
        }

        public async Task<IEnumerable<PhongBanDTO?>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var phongBanEntities = await _repository.PhongBanRepository.GetByIdsAsync(ids, trackChanges);

            if (ids.Count() != phongBanEntities.Count())
                throw new CollectionByIdsBadRequestException();

            var phongBansToReturn = _mapper.Map<IEnumerable<PhongBanDTO>>(phongBanEntities);
            return phongBansToReturn;
        }

        public async Task<PhongBanDTO?> GetPhongBan(Guid id, bool trackChanges)
        {
            var phongBan = await GetPhongBanAndCheckIfItExists(id, trackChanges);

            var companyDto = _mapper.Map<PhongBanDTO>(phongBan);

            return companyDto;
        }

        public async Task<PhongBanDTO> CreatePhongBan(PhongBanForCreationDTO phongBanForCreationDTO)
        {
            var phongBanEntity = _mapper.Map<Phongban>(phongBanForCreationDTO);

            _repository.PhongBanRepository.CreatePhongBan(phongBanEntity);

            await _repository.UnitOfWork.SaveAsync();

            var phongBanToReturn = _mapper.Map<PhongBanDTO>(phongBanEntity);

            return phongBanToReturn;
        }

        public async Task DeletePhongBan(Guid id, bool trackChanges)
        {
            var phongBan = await GetPhongBanAndCheckIfItExists(id, trackChanges);

            _repository.PhongBanRepository.DeletePhongBan(phongBan);

            await _repository.UnitOfWork.SaveAsync();
        }


        public async Task UpdatePhongBan(Guid id, PhongBanForUpdateDTO phongBanForUpdateDTO, bool trackChanges)
        {
            var phongBan = await GetPhongBanAndCheckIfItExists(id, trackChanges);
            
            _mapper.Map(phongBanForUpdateDTO, phongBan);

            await _repository.UnitOfWork.SaveAsync();
        }

        public async Task<Phongban> GetPhongBanAndCheckIfItExists(Guid? id, bool trackChanges)
        {
            if (id == null)
            {
                throw new PhongBanNotFoundException(Guid.Empty);
            }
            var phongban = await _repository.PhongBanRepository.GetPhongBan(id, trackChanges);
            return phongban is null ? throw new PhongBanNotFoundException(id ?? Guid.Empty) : phongban;
        }
    }
}
