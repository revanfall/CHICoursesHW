using Microsoft.EntityFrameworkCore;
using OrderData.Models;

namespace OrderData.EF
{
    public class OrderDataEF
    {
        private ApplicationDbContext _context;

        public OrderDataEF(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connectionString);

            _context = new ApplicationDbContext(optionsBuilder.Options);
        }

        /* Выполнить условие задания 1, но с использованием EF Core */
        public async Task<IEnumerable<Order>> GetOrdersFromLastYear()
        {
            var res = await _context.Orders.Include(u => u.Analysis)
                .Where(o => o.Date >= DateTime.Now.AddYears(-1)).ToListAsync();
            return res;
        }

        /* Выполнить задачи 4-6, но с использованием EF Core */
        public async Task<Order> AddOrder(Order order)
        {
            var created = _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return created.Result.Entity;
        }

        public async Task UpdateOrder(Order order)
        {
            var orderToUpdate = await _context.Orders.FirstOrDefaultAsync(u => u.Id == order.Id);
            if (orderToUpdate != null)
            {
                orderToUpdate.Date = DateTime.Now;
                orderToUpdate.AnalysisId = order.AnalysisId;

                await _context.SaveChangesAsync();
            }

        }

        public async Task DeleteOrder(Order order)
        {
            var orderToUpdate = await _context.Orders.FirstOrDefaultAsync(u => u.Id == order.Id);
            if (orderToUpdate != null)
            {
                _context.Orders.Remove(orderToUpdate);
                await _context.SaveChangesAsync();
            }
        }
    }
}