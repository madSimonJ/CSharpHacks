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


        private static Uri _appendToQuery(Uri url, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            //Create parameter string builder
            var stringBuilder = new StringBuilder();

            //Join parameters
            foreach (var parameter in parameters)
            {
                //If key does not exist, skip parameter
                if (string.IsNullOrWhiteSpace(parameter.Key))
                {
                    continue;
                }

                //Append key
                stringBuilder
                    .Append(parameter.Key);

                //If value exists, append value
                if (!string.IsNullOrWhiteSpace(parameter.Value))
                {
                    stringBuilder
                        .Append("=")
                        .Append(parameter.Value);
                }

                //Mark beginning of next parameter
                stringBuilder
                    .Append("&");
            }

            //If there were no parameters, return url
            //NOTE: Not checking at start of function, 
            // as some pairs could "technically" exist as pairs of nulls
            if (stringBuilder.Length == 0)
            {
                return url;
            }

            //Create parameter string without trailing '&'
            var parametersJoined = stringBuilder.ToString(0, stringBuilder.Length - 1);


            //Create Uri builder from url and get query string
            var uriBuilder = new UriBuilder(url);
            var query = uriBuilder.Query;

            //Append or set parameters
            if (query.Length > 0 && query[0] == '?')
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
