using ExpensesManager.DataAccess.Data;
using ExpensesManager.DataAccess.Repository.IRepository;

namespace ExpensesManager.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Expense = new ExpenseRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public IExpenseRepository Expense { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
