using AspNetNetwork.DataAccess.Data;
using AspNetNetwork.DataAccess.Repository.IRepository;
using AspNetNetwork.Models;


namespace AspNetNetwork.DataAccess.Repository
{
    public class UserRepository:Repository<User>, IUserRepository
    {
        private ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
    }
}
