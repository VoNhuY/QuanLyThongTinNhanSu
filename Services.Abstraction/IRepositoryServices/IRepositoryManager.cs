namespace Services.Abstraction.IRepositoryServices
{
    public interface IRepositoryManager
    {
        IPhongBanRepository PhongBanRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
