using AutoMapper;
using Services.Abstraction.IApplicationServices;
using Services.Abstraction.ILoggerServices;
using Services.Abstraction.IRepositoryServices;

namespace Services.Implementation
{
    public sealed class ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper) : IServiceManager
    {
        private readonly Lazy<IPhongBanService> _phongBanService = new(() => new PhongBanService(repositoryManager, logger, mapper));

        public IPhongBanService PhongBanService => _phongBanService.Value;
    }
}
