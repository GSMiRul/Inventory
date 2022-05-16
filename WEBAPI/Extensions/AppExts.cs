using WEBAPI.Middleware;

namespace WEBAPI.Extensions
{
    public static class AppExts
    {
        public static void UseErrorrHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
