using Contexts;
using Services.Abstraction.IRepositoryServices;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager(QLNSDbContext qlnsDbContext) : IRepositoryManager
    {
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork = new(() => new UnitOfWork(qlnsDbContext));
        private readonly Lazy<IPhongBanRepository> _phongBanRepository = new(() => new PhongBanRepository(qlnsDbContext));

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
        public IPhongBanRepository PhongBanRepository => _phongBanRepository.Value;
    }
}
