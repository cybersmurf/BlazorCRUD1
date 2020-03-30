using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

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

        public Task<List<c_order>> ListAll(int skip, int take,string orderby, string sort="DESC", string search)
        {

        }
    }
}