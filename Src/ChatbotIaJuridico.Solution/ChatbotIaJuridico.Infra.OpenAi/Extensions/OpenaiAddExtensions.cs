using ChatbotIaJuridico.Infra.OpenAi.Clients;
using ChatbotIaJuridico.Infra.OpenAi.Interface;
using ChatbotIaJuridico.Infra.OpenAi.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatbotIaJuridico.Infra.OpenAi.Extensions
{
    public static class OpenaiAddExtensions
    {
        public static void AddInfraOpenAiExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOpenAiRequest, OpenAiRequest>();
            services.AddScoped<IInsumoConverter, InsumoConverter>();
        }
    }
}
