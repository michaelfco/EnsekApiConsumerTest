using EnsekApiConsumer.Application.Interfaces;
using EnsekApiConsumer.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekApiConsumer.Infrastructure.Extension;

public static class DependencyInjection
{
    //DP: Dependency Injection (HttpClient and IMeterReadingService are injected)
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string baseUrl)
    {
        services.AddHttpClient<IMeterReadingService, MeterReadingService>(client =>
        {
            client.BaseAddress = new Uri(baseUrl);
        });     

        return services;
    }
}
