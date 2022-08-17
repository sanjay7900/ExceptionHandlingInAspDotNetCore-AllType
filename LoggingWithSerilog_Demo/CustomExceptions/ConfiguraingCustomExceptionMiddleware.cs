using LoggingWithSerilog_Demo.CustomExceptionMiddlewareHandler;

namespace LoggingWithSerilog_Demo.CustomExceptions
{
    public static class ConfiguraingCustomExceptionMiddlewareExtention
    {
        public static void ApplyCustomException(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionHandler>();

        }
    }
}
