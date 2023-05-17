using ExpensesManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Food",
                },
                new Category
                {
                    Id = 2,
                    Name = "Transport",
                },
                new Category
                {
                    Id = 3,
                    Name = "Mobile Network",
                },
                new Category
                {
                    Id = 4,
                    Name = "Internet",
                },
                new Category
                {
                    Id = 5,
                    Name = "Entertainment",
                }
                );
        }
    }
}
