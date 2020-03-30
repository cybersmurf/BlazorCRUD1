using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorAppWebAssembly.Shared.Models;
using BlazorAppWebAssembly.Shared.Contracts;

namespace BlazorAppWebAssembly.Client.Concrete
{
    public class OrderManager : ICorderManager
    {
        public static Uri AddQuery(this Uri uri, string name, string value)
        {
            // this actually returns HttpValueCollection : NameValueCollection
            // which uses unicode compliant encoding on ToString()
            var query = HttpUtility.ParseQueryString(uri.Query);

            query.Add(name, value);

            var uriBuilder = new UriBuilder(uri)
            {
                Query = query.ToString()
            };

            return uriBuilder.Uri;
        }

        public Task<int> Count(string search)
        {
            throw new NotImplementedException();
        }

        public Task<int> Create(c_order cOrder)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<c_order> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<c_order>> ListAll(int skip, int take, string orderby, string sort = "DESC", string search)
        {
            return null;
        }

        public Task<int> Update(c_order cOrder)
        {
            throw new NotImplementedException();
        }
    }
}
