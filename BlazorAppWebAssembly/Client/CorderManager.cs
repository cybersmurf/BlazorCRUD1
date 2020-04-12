using BlazorAppWebAssembly.Shared.Contracts;
using BlazorAppWebAssembly.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using System;
using BlazorAppWebAssembly.Shared.Extensions;


namespace BlazorAppWebAssembly.Client
{
    internal class CorderManager : ICorderManager
    {
        public HttpClient http;
        

        public CorderManager(HttpClient _http)
        {
            http = _http;

        }
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
            //throw new System.NotImplementedException();
            //var client = new HttpClient();

            var uri = new Uri("api/Corder/ListAll").AddQuery("skip", Convert.ToString(skip));
            // var aaa = client.GetJsonAsync<c_order>("api/Corder/ListAll");
            Console.WriteLine(uri.AbsoluteUri);
            return http.GetJsonAsync<List<c_order>>(uri.AbsoluteUri);
        }

        public Task<int> Update(c_order cOrder)
        {
            throw new System.NotImplementedException();
        }
    }


}