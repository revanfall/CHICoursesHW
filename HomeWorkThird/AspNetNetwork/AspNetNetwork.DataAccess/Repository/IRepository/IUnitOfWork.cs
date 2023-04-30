

namespace AspNetNetwork.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        void Save();
    }
}
