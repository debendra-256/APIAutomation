using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Errors
{
    [Serializable]
    public class ProjectClientException : ApplicationException
    {
        private const string _defaultMessage = "Error in project call";

        public ProjectClientException() :base(_defaultMessage)
        {

        }
        public ProjectClientException(Error error,Exception inner=null) : base(_defaultMessage,inner)
        {

        }
        public ProjectClientException(HttpStatusCode statusCode, Exception inner = null) : base(_defaultMessage, inner)
        {

        }


    }
}
