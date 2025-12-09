using ChatbotIaJuridico.Services.Interfaces;
using ChatbotIaJuridico.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ChatbotIaJuridico.Services.Extensions
{
    public static class addServicesExtensions
    {
        public static void AddServicesStartUp(this IServiceCollection services)
        {            
            services.AddScoped<IAdvogadoServices, AdvogadoServcies>();
            services.AddScoped<IConfiguracaoGeralServices, ConfiguracaoGeralServices>();
            services.AddScoped<IClienteInterfaceServices, ClienteServices>();
            services.AddScoped<IChatInterfaceServices, ChatServices>();
            services.AddScoped<IPreProcessoServices, PreProcessoServices>();
            services.AddScoped<IPreInsumoServices, PreInsumoServices>();
            services.AddScoped<IMenuServices, MenuServices>();
            services.AddScoped<IInsumoServices, InsumoServices>();
            services.AddScoped<IPromptInterfaceServices, PromptServices>();
            services.AddAutoMapper(typeof(addServicesExtensions));
        }
    }
}
