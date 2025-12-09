using ChatbotIaJuridico.Infra;
using ChatbotIaJuridico.Infra.OpenAi.Interface;
using ChatbotIaJuridico.Services.OpenAI.Interfaces;

namespace ChatbotIaJuridico.Services.OpenAI.Services
{
    public class InsumoConverterServices : IInsumoConverterServices
    {
        protected readonly IInsumoConverter _repository;

        public InsumoConverterServices(IInsumoConverter repository)
        {
            _repository = repository;
        }

        public async Task<List<Insumo>> getInsumosText(List<Insumo> insumos, string apikey)
        {
            try
            {
                return await _repository.getInsumosText(insumos, apikey);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
