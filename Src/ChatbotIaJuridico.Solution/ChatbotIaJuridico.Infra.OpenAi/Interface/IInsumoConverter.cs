namespace ChatbotIaJuridico.Infra.OpenAi.Interface
{
    public interface IInsumoConverter
    {
        public Task<List<Insumo>> getInsumosText(List<Insumo> insumos, string apikey);
    }
}
