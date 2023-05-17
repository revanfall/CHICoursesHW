using ExpensesManager.DataAccess.Data;
using ExpensesManager.DataAccess.Repository.IRepository;
using ExpensesManager.Models;

namespace ExpensesManager.DataAccess.Repository
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        private ApplicationDbContext _db;

        public ExpenseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Expense expense)
        {
            var expenseFromDb = _db.Expenses.FirstOrDefault(u => u.Id == expense.Id);
            if (expenseFromDb != null)
            {
                expenseFromDb.SpentMoney = expense.SpentMoney;
                expenseFromDb.Comment = expense.Comment;
                expenseFromDb.CategoryId = expense.CategoryId;
            }
        }
    }
}
