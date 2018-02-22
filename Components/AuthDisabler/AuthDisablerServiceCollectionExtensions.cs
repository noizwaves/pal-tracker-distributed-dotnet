using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthDisabler
{
    public static class AuthDisablerServiceCollectionExtensions
    {
        public static void DisableClaimsVerification(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration.GetValue("DISABLE_AUTH", false))
            {
                services.AddSingleton<IAuthorizationHandler>(sp => new AllowAllClaimsAuthorizationHandler());
            }

        }
    }
}