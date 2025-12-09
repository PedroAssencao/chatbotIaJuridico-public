using ChatbotIaJuridico.Infra;
using ChatbotIaJuridico.Infra.Interfaces;
using ChatbotIaJuridico.Services.Interfaces;

namespace ChatbotIaJuridico.Services.Services
{
    public class ClienteServices : IClienteInterfaceServices
    {
        protected readonly IClientInterface _clienteInterface;

        public ClienteServices(IClientInterface clienteInterface)
        {
            _clienteInterface = clienteInterface;
        }

        public async Task<List<Cliente>> getAllAsync()
        {
            try
            {
                return await _clienteInterface.getAllAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Cliente> getByIdAsync(int id)
        {
            try
            {
                return await _clienteInterface.getByIdAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Cliente> createAsync(Cliente model)
        {
            try
            {
                return await _clienteInterface.createAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Cliente> updateAsync(Cliente model)
        {
            try
            {
                return await _clienteInterface.updateAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Cliente> deleteAsync(Cliente model)
        {
            try
            {
                return await _clienteInterface.deleteAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Cliente> getLastClientCreateByAdvgadoAsync(Advogado advogado)
        {
            try
            {
                return await _clienteInterface.getLastClientCreateByAdvgadoAsync(advogado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Cliente>> getTopEightLastClienteUpdates(Advogado advogado)
        {
            try
            {
                return await _clienteInterface.getTopEightLastClienteUpdates(advogado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Cliente> getClienteByCpfOrName(Advogado advogado, string content)
        {
            try
            {
                return await _clienteInterface.getClienteByCpfOrName(advogado, content);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task updateDataModificacao(Cliente cliente)
        {
            try
            {
                await _clienteInterface.updateDataModificacao(cliente);
                return;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Cliente> getLastClientModfiedByAdvgadoAsync(Advogado advogado)
        {
            try
            {
                return await _clienteInterface.getLastClientModfiedByAdvgadoAsync(advogado);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
