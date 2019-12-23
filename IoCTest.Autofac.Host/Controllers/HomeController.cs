using Autofac;
using IoCTest.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IoCTest.Autofac.Host.Controllers
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
            try
            {
                Parallel.For(0, 200, (index) =>
                {
                    try
                    {
                        var appService = ContainerManager.Container.Resolve<IProductAppService>();
                        var products = appService.GetProducts();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                });
            }
            catch (Exception ex)
            {
                throw;
            }
            _remoteAppService.Test();
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}