using LoggingWithSerilog_Demo.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace LoggingWithSerilog_Demo.CustomExceptionMiddlewareHandler
{
    public class CustomExceptionHandler
    {
        private RequestDelegate _next;
        private ILogger<ErrorViewModel> _logger;

        public CustomExceptionHandler(RequestDelegate next,ILogger<ErrorViewModel> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Apply custom Exception middleware :{ex}");
                await HandlerFunction(context);
            }
        }

        private async Task HandlerFunction(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            context.Response.Headers.ContentType = "application/json";
            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (contextFeature != null)
            {
                _logger.LogError($" something went wrong : {contextFeature.Error}");
                await context.Response.WriteAsync(new ErrorViewModel
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Internal server Eroor ",
                }.ToString());
            }
        }
    }
}
