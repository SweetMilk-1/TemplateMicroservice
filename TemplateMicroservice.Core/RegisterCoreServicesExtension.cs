using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TemplateMicroservice.Core.Infrastructure.HttpClient;
using TemplateMicroservice.Core.Infrastructure.MediatR;
using TemplateMicroservice.Core.Interfaces.HttpClient;

namespace TemplateMicroservice.Core;
public static class RegisterCoreServicesExtension
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        //Add HttpClientService
        services.AddScoped<IHttpClientService, HttpClientService>();
        return services;
    }
}

