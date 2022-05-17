using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Common.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApiVersioningExt(this IServiceCollection services)
        {
           services.AddApiVersioning(conf =>
           {
               conf.DefaultApiVersion = new ApiVersion(1, 0);
               conf.AssumeDefaultVersionWhenUnspecified = true;
               conf.ReportApiVersions = true;
           });
        }
    }
}
