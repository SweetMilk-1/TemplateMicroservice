using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TemplateMicroservice.DAL.Interfaces;

namespace TemplateMicroservice.DAL
{
    public static class RegisterAppDbContextExtension
    {
        /// <summary>
        /// Метод расщирения для регистрации контекста БД
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IServiceCollection AddAppDbContextService(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IAppDbContext, AppDbContext>(options =>
                options.UseNpgsql(connectionString, opt => opt.MigrationsAssembly("TemplateMicroservice")));
            return services;
        }
    }
}
