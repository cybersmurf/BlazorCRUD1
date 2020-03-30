using BlazorAppWebAssembly.Shared.Contracts;
using BlazorAppWebAssembly.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace BlazorAppWebAssembly.Client
{
    internal class CorderManager : ICorderManager
    {
        public Task<int> Count(string search)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Create(c_order cOrder)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<c_order> GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<c_order>> ListAll(int skip, int take, string orderBy, string direction, string search)
        {
            throw new System.NotImplementedException();
           // var client = new HttpClient();
        }

        public Task<int> Update(c_order cOrder)
        {
            throw new System.NotImplementedException();
        }
    }
}