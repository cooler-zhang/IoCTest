using IoCTest.Domain;
using System.Collections.Generic;
using System.Data.Entity;

namespace IoCTest
{
    public class TestDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Catalog> Catalogs { get; set; }

        public TestDbContext()
            : base("Data Source=.;Initial Catalog=Test;User ID=sa;Password=123456")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Catalog>().ToTable("Catalog");
        }
    }
}