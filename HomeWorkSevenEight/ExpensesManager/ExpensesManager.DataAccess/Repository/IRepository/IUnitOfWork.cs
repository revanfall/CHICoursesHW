namespace ExpensesManager.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IExpenseRepository Expense { get; }

        void Save();
    }
}
