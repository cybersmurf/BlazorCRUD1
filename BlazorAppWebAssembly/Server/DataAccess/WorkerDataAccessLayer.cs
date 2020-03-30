using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorAppWebAssembly.Shared.Models;

namespace BlazorAppWebAssembly.Server.DataAccess
{
    public class WorkerDataAccessLayer
    {
        private TprContext db;

        public WorkerDataAccessLayer(TprContext context)
        {
            this.db = context;
        }

        public IEnumerable<worker> GetWorkers()
        {
            try
            {
                return db.worker.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void AddWorker(worker worker)
        {
            try
            {
                db.worker.Add(worker);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateWorker(worker worker)
        {
            try
            {
                db.Entry(worker).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteWorker(ulong id)
        {
            try
            {
                worker worker = db.worker.Find(id);
                db.worker.Remove(worker);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
