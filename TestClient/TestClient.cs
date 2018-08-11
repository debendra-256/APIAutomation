using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Text;



namespace TestClient
{
    public class TestAPIClient:APIRequestHandler
    {
        public static ClientCredential clientCrediantial = null;
        private object ConfigurationManager;

        public TestAPIClient()
        {
            try
            {
                //TestAPIClient.BaseUrl = ConfigurationManager.AppSetting["BaseUri"];

            }
            catch(Exception ex)
            {

            }
        }

    }
}
