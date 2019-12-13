using IoCTest.Contract;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace IoCTest.AppService
{
    public class RemoteAppService : IRemoteAppService
    {
        private readonly HttpClient _client;

        public RemoteAppService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://www.baidu.com/");
        }

        public void Test()
        {
            var result = _client.GetAsync("").Result;
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        ~RemoteAppService()
        {
            Dispose();
        }
    }
}