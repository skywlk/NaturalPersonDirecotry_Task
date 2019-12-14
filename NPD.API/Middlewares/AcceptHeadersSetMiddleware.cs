using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace NPD.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AcceptHeadersSetMiddleware
    {
        private readonly RequestDelegate _next;

        public AcceptHeadersSetMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Request.Headers.Append("Accept-Language", CultureInfo.CurrentCulture.Name);
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AcceptHeadersSetMiddlewareExtensions
    {
        public static IApplicationBuilder UseAcceptHeadersSetMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AcceptHeadersSetMiddleware>();
        }
    }
}
