using IoCTest.Contract;
using IoCTest.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        public IList<ProductDto> GetProducts()
        {
            var query = (from a in _context.Products
                         join b in _context.Catalogs on a.CatalogId equals b.Id into ab
                         from abt in ab.DefaultIfEmpty()
                         select new ProductDto
                         {
                             Id = a.Id,
                             Name = a.Name,
                             Desc = a.Desc,
                             CatalogId = abt.Id,
                             CatalogName = abt.Name
                         });

            var test = query?.FirstOrDefault(a => a.Id == 2)?.Name;

            return query.ToList();
        }
    }
}