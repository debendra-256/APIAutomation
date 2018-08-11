using DataModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClient;
using System.Net.Http;

namespace UserManagementTest
{
    [TestFixture]
    public class User
    {
        TestAPIClient _testclient = new TestAPIClient();
        [Test]
        [Category("User")]
        public async Task PostUserRequest()
        {
            UserDetails user = new UserDetails()
            {
                Email="Admin",
                Password="Password1"
            };

            try
            {
                var result = await _testclient.CheckLogin(user);
                var userResponse = await result.Content.ReadAsAsync<UserDetails>();
                Assert.AreEqual("Admin", userResponse.FirstName);
                Assert.AreEqual("Admin", userResponse.LastName);
                Assert.AreEqual("Bangalore", userResponse.Password);
                
            }
            catch(Exception ex)
            {

            }

        }
    }
}
