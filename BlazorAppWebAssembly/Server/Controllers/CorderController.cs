using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlazorAppWebAssembly.Shared.Models;
using BlazorAppWebAssembly.Server.DataAccess;
using BlazorAppWebAssembly.Server.Concrete;
using BlazorAppWebAssembly.Shared.Contracts;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorAppWebAssembly.Server.Controllers
{
    [Route("api/[controller]")]
    public class CorderController : Controller
    {
        private static TprContext context;
        private CorderDataAccessLayer objcorder;
        private ICorderManager _mngOrder;
        public CorderController(TprContext Appcontext, ICorderManager mngOrder)
        {
            context = Appcontext;
            objcorder = new CorderDataAccessLayer(context);
            _mngOrder = mngOrder;
        }



        [HttpGet]
        [Route("/api/Corder/Index")]
        public IEnumerable<c_order> Index()
        {
            return objcorder.GetAllOrders();
        }
        
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<c_order> Get()
        {
            return objcorder.GetAllOrders();
        }

        [HttpGet ("/ListAll")]
        //[HttpGet("{skip}{take}{orderby}{direction}{search}")]      
        public IEnumerable<c_order> ListAll(int skip, int take, string orderby, string search, string direction = "DESC" )
        {
            return _mngOrder.ListAll(skip, take, orderby, direction, search).Result;
        }

        [HttpGet]
        [Route("/api/Corder/Details/{id}")]
        public c_order Details(ulong id)
        {
            return objcorder.GetOrder(id);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public c_order Get(ulong id)
        {
            return objcorder.GetOrder(id);
        }

        [HttpPost]
        [Route("/api/Corder/Create")]
        public void Create([FromBody]c_order corder)
        {
            if (ModelState.IsValid)
                objcorder.AddOrder(corder);
        }
        
        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]c_order value)
        {
            if (ModelState.IsValid)
                objcorder.AddOrder(value);
        }

        [HttpPut]
        [Route("/api/Corder/Edit")]
        public void Edit([FromBody]c_order corder)
        {
            if (ModelState.IsValid)
                objcorder.UpdateOrder(corder);
        }
        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]c_order value)
        {
            if (ModelState.IsValid)
                objcorder.UpdateOrder(value);
        }

        [HttpDelete]
        [Route("/api/Corder/Delete/{id}")]
        public void DeleteOrder(int id)
        {
            objcorder.DeleteOrder(id);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
