using ChatbotIaJuridico.Infra.Common.client;
using ChatbotIaJuridico.Infra.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ChatbotIaJuridico.Infra.Common.Extensions
{
    public static class addInfraCommon
    {
        public static void AddInfraCommonExtension(this IServiceCollection services)
        {
            services.AddScoped<IHttpClientConfiguration, HttpClientConfiguration>();
            services.AddHttpClient();
        }
    }
}
