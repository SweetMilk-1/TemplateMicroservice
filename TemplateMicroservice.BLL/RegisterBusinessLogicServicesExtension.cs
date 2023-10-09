using Microsoft.Extensions.DependencyInjection;
using TemplateMicroservice.BLL.Interfaces.Services.Person;
using TemplateMicroservice.BLL.Services.Person;

namespace TemplateMicroservice.BLL
{
    public static class RegisterBusinessLogicServicesExtension
    {
        /// <summary>
        /// Реистрирует сервисы бизнес-логики
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddTransient<IPersonService, PersonService>();

            return services;
        }
    }
}
