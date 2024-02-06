using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace HumanForce.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong: {e}");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("[\"There is a error, Please try again!\"]");
            }
        }
    }
}
