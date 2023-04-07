using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC
{
    public static class AddDbContext
    {
        public static IServiceCollection AddSqlServer<TContext>
            (this IServiceCollection services, string connectionString)
            where TContext : DbContext
        {
            services.AddDbContext<TContext>(
                options =>
                    options.UseSqlServer(connectionString,
                     assembly => assembly.MigrationsAssembly(typeof(TContext).Assembly.FullName)
                    ));

            return services;
        }
    }
}
