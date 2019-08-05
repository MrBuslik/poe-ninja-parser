namespace PoeNinja
{
    using Helper;
    using System;

    internal class Program
    {
        static string url = @"https://api.stackexchange.com/2.2/answers?order=desc&sort=activity&site=stackoverflow";

        public static void Main(string[] args)
        {
            string html = string.Empty;

            html = ApiController.GetResponse(url: url);

            Console.WriteLine(html);
        }
    }
}