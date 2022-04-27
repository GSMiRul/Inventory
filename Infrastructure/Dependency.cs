using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Dependency
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, string connectionSrting)
        {
            services.AddDbContext<AppDbContext>(o => o.UseSqlServer(connectionSrting, x => x.MigrationsAssembly("TPProject.Inventory")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            return services;
        }
    }
}
