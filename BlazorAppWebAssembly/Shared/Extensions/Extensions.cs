using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace BlazorAppWebAssembly.Shared.Extensions
{
    public static class Extensions
    {
        public static Uri AddQuery(this Uri uri, string name, string value)
        {
            // this actually returns HttpValueCollection : NameValueCollection
            // which uses unicode compliant encoding on ToString()
            var query = System.Web.HttpUtility.ParseQueryString(uri.Query);

            query.Add(name, value);

            var uriBuilder = new UriBuilder(uri)
            {
                Query = query.ToString()
            };

            return uriBuilder.Uri;
        }
    }
}
