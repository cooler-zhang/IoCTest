using IoCTest.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IoCTest.Unity.Host.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRemoteAppService _remoteAppService;

        public HomeController(IRemoteAppService remoteAppService)
        {
            this._remoteAppService = remoteAppService;
        }

        public ActionResult Index()
        {
            _remoteAppService.Test();
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}