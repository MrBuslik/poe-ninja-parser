// <copyright file="ResponseWrapper.cs" company="YLazakovich">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoeNinja.Application.Utils
{
    using PoeNinja.Application.Helper;
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
                },
            };

            return client.Execute(request);
        }
    }
}