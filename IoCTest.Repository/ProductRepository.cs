using IoCTest.Contract;
using IoCTest.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoCTest.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly TestDbContext _context;

        public ProductRepository(TestDbContext context)
        {
            this._context = context;
        }

        public Product Find(int id)
        {
            return _context.Products.Find(id);
        }
    }
}