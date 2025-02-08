using Biblioteca82.Data.Repositories.Context;
using Biblioteca82.Data.Repositories.Contracts;
using Biblioteca82.Data.Repositories.Implementation;
using Biblioteca82.Services.IServices;
using Biblioteca82.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca82.Services.RegisterService
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            string cadenaConexion = configuration.GetConnectionString("DefaultConnection");

            #region Conección a la base de datos
                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(cadenaConexion).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            #endregion

            #region Inyectar Servicios
            AddServices(services);
            AddRepository(services);
            #endregion

            return services;
        }

        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IRolServices, RolServices>();
        }

        public static void AddRepository(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRolRepository, RolRepository>();
        }
    }
}
