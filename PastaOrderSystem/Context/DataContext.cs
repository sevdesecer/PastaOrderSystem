using Microsoft.EntityFrameworkCore;
using WebApi.Entity;

namespace WebApi.Context
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Pasta> Pasta { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Beverage> Beverage { get; set; }
        public DbSet<ExtraIngredient> ExtraIngredient { get; set; }
        public DbSet<Junction> Junction { get; set; }
    }
}
