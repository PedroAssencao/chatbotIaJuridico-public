namespace ChatbotIaJuridico.Infra.Interfaces
{
    public interface IPreProcessoInterface : IBaseInterface<PreProcesso>
    {
        public Task<PreProcesso> getLastPreProcessoCreateByAdvgadoAsync(Advogado advogado);
        public Task<List<PreProcesso>> getTopEightLastPreProcessoUpdates(Advogado advogado, Cliente cliente);
        public Task<PreProcesso> getPreProcessoByCodigoOuNome(Advogado advogado, string content);
        public Task<List<Insumo>> getAllInsumoByPreProcesso(PreProcesso preProcesso);
    }
}
