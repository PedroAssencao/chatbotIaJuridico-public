using ChatbotIaJuridico.Infra;
using ChatbotIaJuridico.Infra.Interfaces;
using ChatbotIaJuridico.Services.Interfaces;
using System.Net.Http.Headers;

namespace ChatbotIaJuridico.Services.Services
{
    public class PreProcessoServices : IPreProcessoServices
    {
        protected readonly IPreProcessoInterface _repository;

        public PreProcessoServices(IPreProcessoInterface repository)
        {
            _repository = repository;
        }

        public async Task<List<PreProcesso>> getAllAsync()
        {
            try
            {
                return await _repository.getAllAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PreProcesso> getByIdAsync(int id)
        {
            try
            {
                return await _repository.getByIdAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PreProcesso> getLastPreProcessoCreateByAdvgadoAsync(Advogado advogado)
        {
            try
            {
                return await _repository.getLastPreProcessoCreateByAdvgadoAsync(advogado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PreProcesso> createAsync(PreProcesso model)
        {
            try
            {
                return await _repository.createAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PreProcesso> updateAsync(PreProcesso model)
        {
            try
            {
                return await _repository.updateAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PreProcesso> deleteAsync(PreProcesso model)
        {
            try
            {
                return await _repository.deleteAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<PreProcesso>> getTopEightLastPreProcessoUpdates(Advogado advogado, Cliente cliente)
        {
            try
            {
                if (advogado == null || cliente == null)
                {
                    return null;
                }
                return await _repository.getTopEightLastPreProcessoUpdates(advogado, cliente);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PreProcesso> getPreProcessoByCodigoOuNome(Advogado advogado, string content)
        {
            try
            {
                return await _repository.getPreProcessoByCodigoOuNome(advogado, content);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Insumo>> getAllInsumoByPreProcesso(PreProcesso preProcesso)
        {
            try
            {
                return await _repository.getAllInsumoByPreProcesso(preProcesso);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
