using IoCTest.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoCTest.Contract
{
    public interface IProductAppService
    {
        Product Find(int id);

        IList<ProductDto> GetProducts();
    }
}