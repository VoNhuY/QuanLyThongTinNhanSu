using Contexts;
using Entities.DAOs;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Implementation.Extensions;
using Services.Abstraction.IRepositoryServices;

namespace Persistence.Repositories
{
    public class PhongBanRepository(QLNSDbContext repositoryContext) : RepositoryBase<Phongban>(repositoryContext), IPhongBanRepository
    {
        public async Task<PagedList<Phongban>> GetAllPhongBan(PhongBanParameters phongBanParameters, bool trackChanges)
        {
            var subjectes = await FindAll(trackChanges)
                .Search(phongBanParameters.SearchTerm ?? "")
                .Sort(phongBanParameters.OrderBy ?? "name")
                .Skip((phongBanParameters.PageNumber - 1) * phongBanParameters.PageSize)
                .Take(phongBanParameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges)
                .Search(phongBanParameters.SearchTerm ?? "")
                .CountAsync();

            return new PagedList<Phongban>(subjectes, count, phongBanParameters.PageNumber, phongBanParameters.PageSize);
        }

        public async Task<Phongban?> GetPhongBan(Guid? idpb, bool trackChanges) =>
            await FindByCondition(c => c.Idpb.Equals(idpb), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Phongban>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(c => ids.Contains(c.Idpb), trackChanges).ToListAsync();

        public void CreatePhongBan(Phongban phongban) => Create(phongban);
        

        public void DeletePhongBan(Phongban phongban) => Delete(phongban); 
    }
}
