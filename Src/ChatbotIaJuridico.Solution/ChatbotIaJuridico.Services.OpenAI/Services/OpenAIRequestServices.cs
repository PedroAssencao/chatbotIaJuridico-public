using ChatbotIaJuridico.Domain.Models.JsonOpenAiModels;
using ChatbotIaJuridico.Infra;
using ChatbotIaJuridico.Infra.OpenAi.Interface;
using ChatbotIaJuridico.Services.OpenAI.Interfaces;
using Newtonsoft.Json;

namespace ChatbotIaJuridico.Services.OpenAI.Services
{
    public class OpenAIRequestServices : IOpenAIRequestServices
    {
		protected readonly IOpenAiRequest _repository;
        protected readonly IInsumoConverterServices _insumoConverterServices;

        public OpenAIRequestServices(IOpenAiRequest repository, IInsumoConverterServices insumoConverterServices)
        {
            _repository = repository;
            _insumoConverterServices = insumoConverterServices;
        }

        public async Task<GeneratePeticaoRecaive.Root> sendRequestToGeneratePeticao(List<Insumo> Insumos, string url, string Authorization, string prompt)
        {
			try
			{
                var dados = await _repository.sendRequestToGeneratePeticao(Insumos, url, Authorization, prompt);

                GeneratePeticaoRecaive.Root myDeserializedClass = JsonConvert.DeserializeObject<GeneratePeticaoRecaive.Root>(dados);

                return myDeserializedClass;
			}
			catch (Exception)
			{

				throw;
			}
        }

        public async Task<string> sendRequestToGenerateText(List<Insumo> Insumos, string url, string Authorization, string prompt)
        {
            try
            {
                await _insumoConverterServices.getInsumosText(Insumos, Authorization);
                return await _repository.sendRequestToGenerateText(Insumos, url, Authorization, prompt);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
