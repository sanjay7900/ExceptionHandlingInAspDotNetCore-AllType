using LoggingWithSerilog_Demo.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace LoggingWithSerilog_Demo.ExtentionExceptionMiddlewareHandler
{
    public static class ExceptionMiddlewareExtention
    {
        public static void ExceptionMiddleware(this IApplicationBuilder app,ILogger<ErrorViewModel> logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    context.Response.Headers.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature != null)
                    {
                        logger.LogError($" something went wrong : {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorViewModel
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal server Eroor ",
                        }.ToString()) ;
                    }
                });


            });

        }
    }
}
