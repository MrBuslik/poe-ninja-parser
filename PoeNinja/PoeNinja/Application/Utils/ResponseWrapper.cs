namespace PoeNinja.Application.Utils
{
    using Helper;
    using RestSharp;

    public class ResponseWrapper : ApplicationHelper
    {
        private RestClient client;
        
        public ResponseWrapper(RestClient client)
        {
            this.client = client;
        }

        public IRestResponse GetSkillInfo()
        {
            RestRequest request = new RestRequest
            {
                Method = Method.GET,
                Parameters =
                {
                    new Parameter("league", Constants.League, ParameterType.QueryString),
                    new Parameter("type", Constants.Gem, ParameterType.QueryString),
                }
            };

            return client.Execute(request);
        }
    }
}