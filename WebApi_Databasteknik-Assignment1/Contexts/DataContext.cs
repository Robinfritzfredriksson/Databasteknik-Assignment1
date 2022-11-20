using Microsoft.EntityFrameworkCore;
using WebApi_Databasteknik_Assignment1.Models.Entities;

namespace WebApi_Databasteknik_Assignment1.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProductCategoryEntity> productCategories { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
    }
}
