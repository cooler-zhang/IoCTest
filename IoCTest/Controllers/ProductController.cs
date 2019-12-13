using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoCTest.Contract;
using IoCTest.Domain;
using Microsoft.AspNetCore.Mvc;

namespace IoCTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductAppService _appService;
        private readonly IRemoteAppService _remoteAppService;

        public ProductController(IProductAppService appService, IRemoteAppService remoteAppService)
        {
            this._appService = appService;
            this._remoteAppService = remoteAppService;
        }

        public ActionResult<string> Index()
        {
            _remoteAppService.Test();
            return "Working";
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return _appService.Find(id);
        }
    }
}