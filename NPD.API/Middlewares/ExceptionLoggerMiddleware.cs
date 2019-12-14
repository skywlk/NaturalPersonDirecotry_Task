using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using NPD.API.Models;
using NPD.Domain.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;

namespace NPD.API.Middlewares
{
    public class ExceptionLoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IExceptionStorage exceptionStorage)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await exceptionStorage.LogExeptionAsync(ex, Guid.NewGuid());
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ApiException(context.Response.StatusCode, "Something went wrong.").ToString());
        }
    }

    public static class ExceptionLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionLoggerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionLoggerMiddleware>();
        }
    }
}
