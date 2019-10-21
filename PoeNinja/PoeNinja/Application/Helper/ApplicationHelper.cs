// <copyright file="ApplicationHelper.cs" company="YLazakovich">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoeNinja.Application.Helper
{
    using RestSharp;

    /// <summary>
    /// Helper class
    /// </summary>
    public abstract class ApplicationHelper
    {
        protected static string ConvertResponseToJson(IRestResponse response)
        {
            response.ContentType = "application/json";
            
            return response.Content;
        }
    }
}