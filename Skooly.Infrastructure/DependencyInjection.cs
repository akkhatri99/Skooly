using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skooly.Application.Common.Interfaces.Authentication;
using Skooly.Application.Common.Interfaces.Persistence;
using Skooly.Application.Common.Interfaces.Services;
using Skooly.Infrastructure.Authentication;
using Skooly.Infrastructure.Persistence;
using Skooly.Infrastructure.Services;

namespace Skooly.Infrastucture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddSingleton<IJWTTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
