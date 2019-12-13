using IoCTest.Contract;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Unity;

namespace IoCTest.Unity.Host.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRemoteAppService _remoteAppService;
        private readonly IUnityContainer _container;

        public HomeController(IRemoteAppService remoteAppService, IUnityContainer container)
        {
            this._remoteAppService = remoteAppService;
            this._container = container;
        }

        [HttpGet]
        public ActionResult Index()
        {
            _remoteAppService.Test();
            ViewBag.Title = "Home Page";
            return View();
        }

        [HttpGet]
        public ActionResult CallTask()
        {
            var list = new ConcurrentBag<KeyValuePair<int, string>>();
            Parallel.For(0, 50, (index) =>
            {
                var perThreadLifetimeAppService = _container.Resolve<IPerThreadLifetimeAppService>();
                list.Add(new KeyValuePair<int, string>(Thread.CurrentThread.ManagedThreadId, perThreadLifetimeAppService.Test()));
            });
            ViewBag.List = list;
            return View(nameof(Index));
        }
    }
}