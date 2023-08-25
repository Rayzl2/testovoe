using System.Net;
using System.Text.Json;
using Carts.Application.Common.Exceptions;
using FluentValidation;

namespace Carts.WebApi.Middleware
{
    public class CustomExceptionHandler
    {
        private readonly RequestDelegate _requestDelegate;

        public CustomExceptionHandler(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context) {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var status = HttpStatusCode.InternalServerError;
            var res = string.Empty;

            switch(ex)
            {
                case ValidationException validationException:
                    status = HttpStatusCode.BadRequest;
                    res = JsonSerializer.Serialize(validationException.Errors);
                    break;

                case NotFound:
                    status = HttpStatusCode.NotFound;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            if (res == string.Empty)
            {
                res = JsonSerializer.Serialize(new { error= ex.Message});
            }

            return context.Response.WriteAsync(res);
        }
    }
}
