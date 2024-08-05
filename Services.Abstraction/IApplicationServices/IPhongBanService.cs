using Entities.DTOs.CRUD;
using Entities.RequestFeatures;

namespace Services.Abstraction.IApplicationServices
{
    public interface IPhongBanService
    {
        Task<(IEnumerable<PhongBanDTO> phongBanDTO, MetaData metaData)> GetAllPhongBan(PhongBanParameters phongBanParameters, bool trackChanges);

        Task<PhongBanDTO?> GetPhongBan(Guid id, bool trackChanges);

        Task<IEnumerable<PhongBanDTO?>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);

        Task<PhongBanDTO> CreatePhongBan(PhongBanForCreationDTO phongBanForCreationDTO);

        Task UpdatePhongBan(Guid id, PhongBanForUpdateDTO classForUpdate, bool trackChanges);

        Task DeletePhongBan(Guid id, bool trackChanges);
    }
}
