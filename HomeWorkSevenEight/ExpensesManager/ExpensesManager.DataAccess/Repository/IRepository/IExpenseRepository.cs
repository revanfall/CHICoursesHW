using ExpensesManager.Models;

namespace ExpensesManager.DataAccess.Repository.IRepository
{
    public interface IExpenseRepository:IRepository<Expense>
    {
        void Update(Expense expense);
    }
}
