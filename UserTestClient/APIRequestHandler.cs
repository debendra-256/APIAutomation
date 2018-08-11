using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    public class APIRequestHandler
    {
        

        public APIRequestHandler()
        {
            TestAPIClient.BaseUrl = ConfigurationManager.AppSettings["Baseurl"];
        }

        
    }
}
