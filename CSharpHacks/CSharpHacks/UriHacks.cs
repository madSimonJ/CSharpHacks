using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpHacks
{
    public static class UriHacks
    {
        public static Uri AddParameter(this Uri url, IEnumerable<KeyValuePair<string, string>> parameters)
            => _appendToQuery(url, parameters);

        public static Uri AddParameter(this Uri url, params KeyValuePair<string, string>[] parameters)
            => url.AddParameter(parameters as IEnumerable<KeyValuePair<string, string>>);

        public static Uri AddParameter(this Uri url, string key, string value = null)
            => url.AddParameter(new KeyValuePair<string, string>(key, value));


        private static Uri _appendToQuery(in Uri url, in IEnumerable<KeyValuePair<string, string>> parameters)
        {
            //Create enumerable of string of key value
            var parametersNormalized = parameters
                //If key does not exist, skip parameter
                .Where(p => !string.IsNullOrWhiteSpace(p.Key))
                //If value exists, append value, else only append key
                .Select(p => !string.IsNullOrWhiteSpace(p.Value) ? $"{p.Key}={p.Value}" : p.Key);

            //Join parameters with '&'
            var parametersJoined = string.Join("&", parametersNormalized);


            //Create Uri builder from url and get query string
            var uriBuilder = new UriBuilder(url);
            var query = uriBuilder.Query;

            //Append or set parameters
            if (parametersJoined.Length == 0)
            {
                //Do nothing, we still need to return a new Uri object though
                // to be consistent in the object being returned.
            }
            else if (query.Length > 0 && query[0] == '?')
            {
                uriBuilder.Query = $"{query.Substring(1)}&{parametersJoined}";
            }
            else
            {
                uriBuilder.Query = $"{parametersJoined}";
            }


            //Return updated URI
            return uriBuilder.Uri;
        }
    }
}
