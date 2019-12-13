using IoCTest.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IoCTest
{
    public class TestDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Catalog> Catalogs { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Test;User ID=sa;Password=123456");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}