using System;
using System.Net;
using System.Threading.Tasks;
using DataLuna.Back.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DataLuna.Back.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            string message = string.Empty;

            if (ex is HttpStatusCodeException statusCodeException)
            {
                code = statusCodeException.StatusCode;
                message = statusCodeException.Message;
            }
            
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(new { error = message }));
        }
    }
}