﻿using System;
using System.Net;
using RestSharp;

namespace BusBoard.Api
{
    public class PostCodeApiHandler
    {
        private string _url
        {
            get => "https://api.postcodes.io/postcodes";
        }

        private IRestClient _client
        {
            get => new RestClient(_url);
        }
        
        public Coordinate GetCoordinate(string postCode)
        {
            var  request = new RestRequest(postCode);
            request.RootElement = "result";
            var response = _client.Execute<Coordinate>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine("Invalid postal code");
                return null;
            }
            
            return response.Data;
        }
    }
}