using ExpensesManager.DataAccess.Data;
using ExpensesManager.DataAccess.Repository.IRepository;
using ExpensesManager.Models;

namespace ExpensesManager.DataAccess.Repository
{
    public class CategoryRepository:Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            _db.Update(category);
        }
    }
}
