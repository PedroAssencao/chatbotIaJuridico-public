using ChatbotIaJuridico.Domain.Models.JsonOpenAiModels;
using ChatbotIaJuridico.Infra;

namespace ChatbotIaJuridico.Services.OpenAI.Interfaces
{
    public interface IOpenAIRequestServices
    {
        public Task<GeneratePeticaoRecaive.Root> sendRequestToGeneratePeticao(List<Insumo> Insumos, string url, string Authorization, string prompt);
        public Task<string> sendRequestToGenerateText(List<Insumo> Insumos, string url, string Authorization, string prompt);
    }
}
