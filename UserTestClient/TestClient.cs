using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using static TestClient.APIRequestHandler;
using DataModel;

namespace TestClient
{
    public enum Methods
    {
        Get = 0,
        Post = 1,
        Put = 2,
        Delete = 3

    }
    public class TestAPIClient : APIRequestHandler
    {
        public static ClientCredential clientCrediantial = null;
        private object ConfigurationManager;
        public string accessToken;
        public string SessionId;

        protected AuthenticationContext authContext = null;
        protected AuthenticationResult result = null;
        public static string BaseUrl { get; set; }
        HttpClient httpclient;

        public TestAPIClient()
        {
            try
            {
                //TestAPIClient.BaseUrl = ConfigurationManager.AppSetting[""];

            }
            catch (Exception ex)
            {

            }
        }


        public async Task<HttpResponseMessage> CheckLogin(UserDetails details )
        {
            var response = await SendRequest(
                Methods.Post,
                string.Format("User/SignIn"),
                new[] { HttpStatusCode.OK }).ConfigureAwait(false);
            return response;
        }

        //private async Task<HttpResponseMessage> SendRequest<T>(Methods method, string uri, IEnumerable<HttpStatusCode> successstatusCode, T body = null, string apiName = null) where T : class
        //{
        //    return await ExecuteRequest<object>(method, uri,body, successstatusCode, null, apiName).ConfigureAwait(false);

        //}
        public async Task<HttpResponseMessage> SendRequest<T>(Methods method, string uri, T body=null,string APIName=null) where T:class
        {
            var Json = new JsonSerializerSettings();
            Json.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            Json.NullValueHandling = NullValueHandling.Ignore;
            var Formatter = new JsonMediaTypeFormatter { SerializerSettings = Json };
            HttpResponseMessage response;
            using (httpclient = new HttpClient(createHandler()) { BaseAddress = new Uri("http://localhost:13892/") })
            {

                if (!string.IsNullOrEmpty(accessToken))
                {
                    httpclient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                    httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/Json"));
                }
                switch (method)
                {
                    case Methods.Get:
                        response = await httpclient.GetAsync(uri);
                        break;
                    case Methods.Post:
                        if (body != null)
                        {
                            response = await httpclient.PostAsync(uri, body, Formatter);
                        }
                        else
                        {
                            response = await httpclient.PostAsync(uri, new StringContent(string.Empty));
                        }
                        break;
                    case Methods.Put:
                        if (body != null)
                        {
                            response = await httpclient.PutAsync(uri, body, Formatter);
                        }
                        else
                        {
                            response = await httpclient.PutAsync(uri, new StringContent(string.Empty));
                        }
                        break;
                    case Methods.Delete:
                        if (body != null)
                        {
                            response = await httpclient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, uri) { Content = new ObjectContent<T>(body, new JsonMediaTypeFormatter()) });
                        }
                        else
                        {
                            response = await httpclient.DeleteAsync(uri);
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Method");
                }

            }
            httpclient.DefaultRequestHeaders.Authorization = null;
            return response;
        

        }
        public WebRequestHandler createHandler()
        {
            var clientHandler = new WebRequestHandler();
            clientHandler.CookieContainer = new System.Net.CookieContainer();
            return clientHandler;
        }

       



    }
}
