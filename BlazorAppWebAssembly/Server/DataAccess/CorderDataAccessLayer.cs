using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BlazorAppWebAssembly.Shared.Models;

namespace BlazorAppWebAssembly.Server.DataAccess
{
    public class CorderDataAccessLayer
    {
        private TprContext db;

        public CorderDataAccessLayer(TprContext context)
        {
            this.db = context;
        }

        public IEnumerable<c_order> GetAllOrders()
        {
            try
            {
                return db.c_order.ToList().Take(100);
            }
            catch
            {
                throw;
            }
        }

        public void AddOrder(c_order corder)
        {
            try
            {
                db.c_order.Add(corder);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateOrder(c_order corder)
        {
            try
            {
                db.Entry(corder).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public c_order GetOrder(ulong id)
        {
            try
            {
                c_order corder = db.c_order.Find(id);
                return corder;
            }
            catch
            {
                throw;
            }

        }
            
        public void DeleteOrder(int id)
        {
            try
            {
                c_order corder = db.c_order.Find(id);
                db.c_order.Remove(corder);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

    } //end of layer


}
