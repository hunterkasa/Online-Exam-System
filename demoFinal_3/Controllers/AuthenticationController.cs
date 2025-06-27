using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Services;
using demoFinal_3.Models;

namespace demoFinal_3.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthenticationController : ApiController
    {
        private readonly AuthenticationService authenticationService;

        public AuthenticationController()
        {
            authenticationService = new AuthenticationService();
        }

        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var token = authenticationService.AuthenticateUser(loginModel.Email, loginModel.Password);
            if (token != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, token);
            }

            return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid email or password.");
        }
    }
}
