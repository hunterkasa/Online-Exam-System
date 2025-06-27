using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Linq;

namespace demoFinal_3.Auth
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class LoggedAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var request = actionContext.Request;
            var authHeader = request.Headers.Authorization;

            if (authHeader == null || authHeader.Scheme != "Bearer")
            {
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.Unauthorized, "Authorization header missing or invalid. Use 'Bearer {token}' format.");
                return;
            }
            var token = authHeader.Parameter;
            if (string.IsNullOrEmpty(token))
            {
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.Unauthorized, "Token is missing.");
                return;
            }
            base.OnActionExecuting(actionContext);
        }
    }
}