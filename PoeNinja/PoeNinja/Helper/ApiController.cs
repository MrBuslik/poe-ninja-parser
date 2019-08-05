namespace PoeNinja.Helper
{
    using System;
    using System.Net;
    using System.IO;

    public static class ApiController
    {
        private static HttpWebRequest DoRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            
            return request;
        }

        public static string GetResponse(string url)
        {
            string html = string.Empty;

            var request = DoRequest(url);
            
            using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            return html;
        }
    }
}