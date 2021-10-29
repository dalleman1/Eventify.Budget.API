using Microsoft.EntityFrameworkCore;

namespace Eventify.Budget.DomainLogic
{
    public class BudgetContext : DbContext
    {
        public DbSet<Budget> budgets { get; set; }
        public DbSet<Item> items { get; set; }
        public BudgetContext(DbContextOptions<BudgetContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Budget>()
                .HasMany(c => c.Items)
                .WithOne(e => e.budget);

        }
    }
}
