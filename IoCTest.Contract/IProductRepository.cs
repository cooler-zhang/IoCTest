using IoCTest.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoCTest.Contract
{
    public interface IProductRepository
    {
        Product Find(int id);
    }
}