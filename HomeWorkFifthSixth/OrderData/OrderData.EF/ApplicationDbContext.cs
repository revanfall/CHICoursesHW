using Microsoft.EntityFrameworkCore;
using OrderData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderData.EF
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Analysis> Analysis { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
