using ChatbotIaJuridico.Infra.Storage.Interfaces;
using ChatbotIaJuridico.Infra.Storage.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ChatbotIaJuridico.Infra.Storage.Extensions
{
    public static class addInfraStorageExtensions
    {
        public static void AddInfraStorageStartUp(this IServiceCollection services)
        {
            services.AddScoped<IFileManager, FileManager>();
        }
    }
}
