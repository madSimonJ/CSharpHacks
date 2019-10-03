using System;

namespace CSharpHacks
{
    public static class UriHacks
    {
        public static Uri AddParameter(this Uri url, string name, string value)
        {
            var uriBuilder = new UriBuilder(url);
            var query = uriBuilder.Query;
            if (query.Length > 0 && query[0] == '?')
            {
                uriBuilder.Query = $"{query.Substring(1)}&{name}={value}";
            }
            else
            {
                uriBuilder.Query = $"{name}={value}";
            }
            
            return uriBuilder.Uri;
        }
    }
}
