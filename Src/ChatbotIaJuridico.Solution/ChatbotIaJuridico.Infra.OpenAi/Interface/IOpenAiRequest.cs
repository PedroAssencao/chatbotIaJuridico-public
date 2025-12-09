namespace ChatbotIaJuridico.Infra.OpenAi.Interface
{
    public interface IOpenAiRequest
    {
        public Task<string> sendRequestToGeneratePeticao(List<Insumo> Insumos, string url, string Authorization, string prompt);
        public Task<string> sendRequestToGenerateText(List<Insumo> Insumos, string url, string Authorization, string prompt);
    }
}
