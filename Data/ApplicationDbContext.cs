using MvcPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace MvcPlanner.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<Item> Items { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Planner> PlannedWork { get; set; }
    }
}
