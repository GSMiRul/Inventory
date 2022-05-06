using Application.Brands.Commands.CreateBrand;
using Application.Brands.EventHandlers.Brands;
using Application.Common.Interfaces;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Dependency
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("DevConection"), 
                x => x.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
            services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

            return services;
        }
    }
}
