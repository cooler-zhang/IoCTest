using IoCTest.Contract;
using IoCTest.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoCTest.AppService
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _repository;

        public ProductAppService(IProductRepository repository)
        {
            this._repository = repository;
        }

        public Product Find(int id)
        {
            return _repository.Find(id);
        }
    }
}