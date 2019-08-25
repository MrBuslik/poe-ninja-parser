namespace PoeNinja.Application.Utils
{
    using System;
    using System.IO;
    using System.Net;

    public static class ApiController
    {
        public static string GetJson(string url)
        {
            string html = string.Empty;

            var request = DoRequest(url);
            
            using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();

                Console.WriteLine($"Sending {response.Method} request to URL: {response.ResponseUri}");
                Console.WriteLine($"Response code: {response.StatusCode}");
            }

            return html;
        }

        private static HttpWebRequest DoRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            
            return request;
        }
    }
}