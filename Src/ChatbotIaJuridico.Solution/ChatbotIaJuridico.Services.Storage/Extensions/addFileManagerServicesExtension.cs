using ChatbotIaJuridico.Services.Storage.Interface;
using ChatbotIaJuridico.Services.Storage.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ChatbotIaJuridico.Services.Storage.Extensions
{
    public static class addFileManagerServicesExtension
    {
        public static void AddFileManagerServicesStartUp(this IServiceCollection services)
        {
            services.AddScoped<IFileManagerServices, FileManagerServices>();
        }
    }
}
