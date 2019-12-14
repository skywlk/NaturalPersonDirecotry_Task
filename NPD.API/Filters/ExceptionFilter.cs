using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NPD.API.Models;
using NPD.Domain.Exceptions;
using System;
using System.Net;

namespace NPD.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ApiResponseModel<ApiException> apiException = null;

            if (context.Exception.GetType().IsSubclassOf(typeof(NPDDomainException)) || context.Exception is NPDDomainException)
            {
                var ex = context.Exception as NPDDomainException;
                //context.Exception = null;
                apiException = new ApiResponseModel<ApiException>(false, new ApiException(500, ex.Message));
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                //context.Exception = null;
                apiException = new ApiResponseModel<ApiException>(false, new ApiException(401, ""));
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                apiException = new ApiResponseModel<ApiException>(false, new ApiException(500, "Something went wrong"));
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            context.Result = new JsonResult(apiException);
        }
    }
}
