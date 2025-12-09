using ChatbotIaJuridico.Infra.DAL;
using ChatbotIaJuridico.Infra.Interfaces;
using ChatbotIaJuridico.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatbotIaJuridico.Infra.Extensions
{
    public static class AddInfraExtensions
    {
        public static void AddRepositoryStartUp(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChatbotIaJuridicoContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Chinook"));
            });
            services.AddScoped<IAdvogadoInterface, AdvogadoRepository>();
            services.AddScoped<IChatInterface, ChatRepository>();
            services.AddScoped<IClientInterface, ClienteRepository>();
            services.AddScoped<IConfiguracaoGeral, ConfiguracaoGeralRepository>();
            services.AddScoped<IPreProcessoInterface, PreProcessoRepository>();
            services.AddScoped<IMenuInterface, MenuRepository>();
            services.AddScoped<IPreInsumo, PreInsumoRepository>();
            services.AddScoped<IInsumoInterface, InsumoRepository>();
            services.AddScoped<IPromptInterface, PromptRepository>();
        }
    }
}
