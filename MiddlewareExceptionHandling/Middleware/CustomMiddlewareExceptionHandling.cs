namespace MiddlewareExceptionHandling.Middleware
{
    public class CustomMiddlewareExceptionHandling
    {
        private readonly RequestDelegate _next;

        public CustomMiddlewareExceptionHandling(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Call the next delegate/middleware in the pipeline.
                await _next(context);
            }
            catch (Exception e)
            {
                // This is just one example, in practice, the exception handling for an application will be more complex.
                // Sometimes the result is an error message, other times it is a different kind of corrective actions, or sending an alert to an admin.
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(e.Message);
            }
        }
    }
    public static class CustomMiddlewareExceptionHandlingExtensions
    {
        public static IApplicationBuilder AddCustomExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddlewareExceptionHandling>();
        }
    }
}