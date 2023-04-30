using AspNetNetwork.DataAccess.Data;
using AspNetNetwork.DataAccess.Repository.IRepository;
using AspNetNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetNetwork.DataAccess.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Users = new UserRepository(db);
        }

        public IUserRepository Users { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
