using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TestClient
{
    public class APIRequestHandler
    {
        public enum Methods
        {
            Get=0,
            Post=1,
            Put=2,
            Delete=3

        }
        protected AuthenticationContext authContext = null;
        protected AuthenticationResult result = null;
        public static string BaseUrl { get; set; }
        protected HttpClient ApiClient = new HttpClient();

        public APIRequestHandler()
        {

        }

    }
}
