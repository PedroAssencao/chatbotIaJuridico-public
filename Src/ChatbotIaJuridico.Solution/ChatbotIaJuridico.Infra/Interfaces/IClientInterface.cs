namespace ChatbotIaJuridico.Infra.Interfaces
{
    public interface IClientInterface : IBaseInterface<Cliente>
    {
        public Task<Cliente> getLastClientCreateByAdvgadoAsync(Advogado advogado);
        public Task<Cliente> getLastClientModfiedByAdvgadoAsync(Advogado advogado);
        public Task<List<Cliente>> getTopEightLastClienteUpdates(Advogado advogado);
        public Task<Cliente> getClienteByCpfOrName(Advogado advogado, string content);
        public Task updateDataModificacao(Cliente cliente);
    }
}
