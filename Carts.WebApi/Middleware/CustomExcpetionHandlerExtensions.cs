namespace Carts.WebApi.Middleware
{
    public static class CustomExcpetionHandlerExtensions
    {
        public static IApplicationBuilder ClientExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandler>();
        }
    }
}
