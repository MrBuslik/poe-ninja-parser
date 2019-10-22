// <copyright file="ApplicationHelper.cs" company="YLazakovich">
// Copyright (c) YLazakovich. All rights reserved.
// </copyright>

namespace PoeNinja.Application.Helper
{
    using RestSharp;

    /// <summary>
    /// Helper class.
    /// </summary>
    public abstract class ApplicationHelper
    {
        /// <summary>
        /// Returns response content in json format.
        /// </summary>
        /// <param name="response">response.</param>
        /// <returns>JSON Content.</returns>
        protected static string ConvertResponseToJson(IRestResponse response)
        {
            response.ContentType = "application/json";

            return response.Content;
        }
    }
}