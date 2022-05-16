using Application.Brands.Commands.CreateBrand;
using Application.Brands.EventHandlers.Brands;
using Application.Common.Interfaces;
using Domain.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
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
            services.AddDbContext<AppDbContext>(op => op.UseSqlServer(
                configuration.GetConnectionString("DevConection"), 
                x => x.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
            //services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

            services.AddTransient(typeof(IWriteBaseRepository<>), typeof(WriteRepository<>));
            services.AddTransient(typeof(IReadBaseRepository<>), typeof(ReadRepository<>));
            services.AddTransient<IDateTimeService, DateTimeService>();

            return services;
        }
    }
}
