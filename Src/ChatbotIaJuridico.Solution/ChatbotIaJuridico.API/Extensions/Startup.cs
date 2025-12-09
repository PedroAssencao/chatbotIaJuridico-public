using ChatbotIaJuridico.Infra.Common.Extensions;
using ChatbotIaJuridico.Infra.Extensions;
using ChatbotIaJuridico.Infra.Meta.Extensions;
using ChatbotIaJuridico.Infra.OpenAi.Extensions;
using ChatbotIaJuridico.Infra.Storage.Extensions;
using ChatbotIaJuridico.Services.Extensions;
using ChatbotIaJuridico.Services.Meta.Extensions;
using ChatbotIaJuridico.Services.OpenAI.Extensions;
using ChatbotIaJuridico.Services.Storage.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;

namespace ChatbotIaJuridico.API.Extensions
{
    public static class Startup
    {
        public static void StartConfiguration(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddInfraCommonExtension();
        }

        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.StartConfiguration();
            services.AddRepositoryStartUp(configuration);
            services.AddServicesStartUp();
            services.AddAuthorization();
            services.ConfigureServicesMeta(configuration);
            services.ConfigureServicesOpenAi(configuration);
            services.ConfigureServicesFileManager(configuration);
        }

        public static void ConfigureServicesMeta(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfraMetaExtension();
            services.AddMetaServicesStartUp();
        }

        public static void ConfigureServicesOpenAi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServicesOpenaAi();
            services.AddInfraOpenAiExtensions(configuration);
        }

        public static void ConfigureServicesFileManager(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfraStorageStartUp();
            services.AddFileManagerServicesStartUp();
        }

        public static void Configure(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();


            var arquivosPath = Path.Combine(Directory.GetCurrentDirectory(), "arquivos");

            if (!Directory.Exists(arquivosPath))
            {
                Directory.CreateDirectory(arquivosPath);
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(arquivosPath),
                RequestPath = "/arquivos",
                ServeUnknownFileTypes = true,
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
