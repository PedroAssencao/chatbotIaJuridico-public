using ChatbotIaJuridico.Infra;

namespace ChatbotIaJuridico.Services.Interfaces
{
    public interface IClienteInterfaceServices : IBaseInterfaceServices<Cliente>
    {
        public Task<Cliente> getLastClientCreateByAdvgadoAsync(Advogado advogado);
        public Task<List<Cliente>> getTopEightLastClienteUpdates(Advogado advogado);
        public Task<Cliente> getClienteByCpfOrName(Advogado advogado, string content);
        public Task updateDataModificacao(Cliente cliente);

        public Task<Cliente> getLastClientModfiedByAdvgadoAsync(Advogado advogado);
    }
}
