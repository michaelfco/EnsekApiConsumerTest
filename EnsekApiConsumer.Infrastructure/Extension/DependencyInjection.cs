using EnsekApiConsumer.Application.Interfaces;
using EnsekApiConsumer.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
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
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {               

        var apiSettings = configuration.GetSection("ApiSettings").Get<ApiSettings>();

        services.AddHttpClient("ApiClient", client =>
        {
            client.BaseAddress = new Uri(apiSettings.BaseUrl);
        });

        services.AddScoped<IMeterReadingService, MeterReadingService>();

        return services;
    }
}
