using ChatbotIaJuridico.Services.OpenAI.Interfaces;
using ChatbotIaJuridico.Services.OpenAI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ChatbotIaJuridico.Services.OpenAI.Extensions
{
    public static class addServicesOpenaAiExtensions 
    {
        public static void AddServicesOpenaAi(this IServiceCollection services)
        {
            services.AddScoped<IOpenAIRequestServices, OpenAIRequestServices>();
            services.AddScoped<IInsumoConverterServices, InsumoConverterServices>();

        }
    }
}
