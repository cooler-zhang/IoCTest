using System;
using System.Collections.Generic;
using System.Text;

namespace IoCTest.Contract
{
    public interface IPerThreadLifetimeAppService
    {
        string Test();
    }
}