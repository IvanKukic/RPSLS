using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RPSLS.Application.Exceptions;
using RPSLS.Application.Services;
using System.Reflection;

namespace RPSLS.Application;

public static class ApplicationServiceRegistration
{
    private const string BASE_URL_CONFIG_NAME = "BaseUrl";
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        //TODO: find more efficient way to register this to avoid using reflection 
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddHttpClient(
            nameof(RandomNumberHttpService),
            config => 
            {
                var baseUrl = configuration.GetValue<string>(BASE_URL_CONFIG_NAME);
                if(string.IsNullOrEmpty(baseUrl))
                {
                    throw new ConfigurationMissingException(nameof(BASE_URL_CONFIG_NAME));
                }
                config.BaseAddress = new Uri(baseUrl);
            }
            );
        services.AddTransient<RandomNumberHttpService>();
    }
}
