using IoCTest.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoCTest.AppService
{
    public class PerThreadLifetimeAppService : IPerThreadLifetimeAppService
    {
        private readonly Guid _guid;

        public PerThreadLifetimeAppService()
        {
            this._guid = Guid.NewGuid();
        }

        public string Test()
        {
            return _guid.ToString();
        }
    }
}