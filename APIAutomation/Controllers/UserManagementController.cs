using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace APIAutomation.Controllers
{
    [RoutePrefix("User")]
    public class UserManagementController : ApiController
    {
        Dictionary<string, string> dictSucc;
        Dictionary<string, string> dictErrorMess;
        [Route("SignIn")]
        [HttpPost]
        [ResponseType(typeof(UserDetails))]
        
        public async Task<HttpResponseMessage> signin(UserDetails userdetailModel)
        {
            try
            {
                if (userdetailModel.Email == "" && userdetailModel.Password == "")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,ErrorCodes.UserIdNotFount);
                }

                    if (userdetailModel.Email == "Admin" && userdetailModel.Password == "Password")
                    {
                        dictSucc = new Dictionary<string, string>();
                        UserDetails _userdetils = new UserDetails()
                        {
                            FirstName = "ADMIN",
                            LastName = "ADMIN",
                            LocationName = "Banglore",
                            Email = "ADMIN"

                        };
                        return Request.CreateResponse(HttpStatusCode.OK, _userdetils);
                    }
                    else
                    {
                        dictErrorMess = new Dictionary<string, string>();
                        dictErrorMess.Add("Error", "Please check Email or password");
                        return Request.CreateResponse(HttpStatusCode.BadRequest, dictErrorMess);
                    }

            }
   
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }

        }

            
    }
}
