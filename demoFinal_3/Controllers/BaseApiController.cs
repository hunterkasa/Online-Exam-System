using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace demoFinal_3.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        protected HttpResponseMessage CreateSuccessResponse<T>(T data, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return Request.CreateResponse(statusCode, data);
        }

        protected HttpResponseMessage CreateErrorResponse(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            return Request.CreateErrorResponse(statusCode, message);
        }

        protected HttpResponseMessage HandleException(Exception ex)
        {
            // Log the exception here if you have logging configured
            return CreateErrorResponse(ex.Message);
        }
    }
} 