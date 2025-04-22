using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace CollegeSystem2.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            try
            {
                 _next(context);
            }
            catch (Exception ex)
            {
                 HandleException(context, ex);
            }
            return Task.CompletedTask;
        }

        private static void HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorResponse = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "An unexpected error occurred. Please try again later."
            };

            var jsonResponse = JsonSerializer.Serialize(errorResponse);

            
            context.Response.WriteAsync(jsonResponse);
        }
    }
}
