using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlazorAppWebAssembly.Shared.Models;
using BlazorAppWebAssembly.Server.DataAccess;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorAppWebAssembly.Server.Controllers
{

    [Route("api/[controller]")]
    public class WorkerController : Controller
    {
        private static TprContext context;
        private WorkerDataAccessLayer objworker;

        public WorkerController(TprContext tprContext)
        {
            context = tprContext;
            objworker = new WorkerDataAccessLayer(context);

        }

        [HttpGet]
        [Route("api/Worker/Index")]
        public IEnumerable<worker> Index()
        {
            return objworker.GetWorkers();
        }

        [HttpGet]
        public IEnumerable<worker> Get()
        {
            return objworker.GetWorkers();
        }
    }
}
