namespace PoeNinja.Application
{
    using Newtonsoft.Json.Linq;
    using Utils;

    internal class Program
    {
        static string url = @"https://poe.ninja/api/data/itemoverview?league=Legion&type=SkillGem";

        public static void Main(string[] args)
        {
            string json = string.Empty;

            json = ApiController.GetJson(url: url);
            JObject jObject = JObject.Parse(json);

            Manager.InitJson(jObject);
        }
    }
}