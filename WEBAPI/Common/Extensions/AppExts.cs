using WEBAPI.Middleware;

namespace WEBAPI.Common.Extensions
{
    public static class AppExts
    {
        public static void UseErrorrHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
