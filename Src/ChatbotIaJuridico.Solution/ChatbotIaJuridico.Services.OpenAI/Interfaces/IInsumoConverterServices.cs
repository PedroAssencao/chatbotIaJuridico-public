using ChatbotIaJuridico.Infra;

namespace ChatbotIaJuridico.Services.OpenAI.Interfaces
{
    public interface IInsumoConverterServices
    {
        public Task<List<Insumo>> getInsumosText(List<Insumo> insumos, string apikey);
    }
}
