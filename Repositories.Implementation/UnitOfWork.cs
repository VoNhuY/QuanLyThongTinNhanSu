using Contexts;
using Services.Abstraction.IRepositoryServices;

namespace Persistence.Repositories
{
    internal sealed class UnitOfWork(QLNSDbContext qlnsDbContext) : IUnitOfWork
    {

        private readonly QLNSDbContext _qlnsDbContext = qlnsDbContext;

        public async Task SaveAsync() => await _qlnsDbContext.SaveChangesAsync();
    }
}
