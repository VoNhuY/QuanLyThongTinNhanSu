using Entities.DAOs;
using Entities.RequestFeatures;

namespace Services.Abstraction.IRepositoryServices
{
    public interface IPhongBanRepository
    {

        Task<PagedList<Phongban>> GetAllPhongBan(PhongBanParameters phongBanParameters, bool trackChanges);


        Task<Phongban?> GetPhongBan(Guid? idpb, bool trackChanges);

        Task<IEnumerable<Phongban>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);

        void CreatePhongBan(Phongban phongban);

        void DeletePhongBan(Phongban phongban);
    }
}
