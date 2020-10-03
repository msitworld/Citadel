using Citadel.RahkaranClient.Models.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Citadel.RahkaranClient.Services;

namespace Citadel.RahkaranClient
{
    public static class ServiceRegister
    {
        public static void AddRahkaranClient(this IServiceCollection services, Configuration configuration)
        {
            services.AddSingleton(provider => new RahkaranService(configuration));
        }
    }
}
