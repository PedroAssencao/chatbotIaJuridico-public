using ChatbotIaJuridico.Domain.Models.Enum;
using ChatbotIaJuridico.Domain.Models.JsonMetaModels;
using ChatbotIaJuridico.Infra;
using ChatbotIaJuridico.Infra.Interfaces;
using ChatbotIaJuridico.Services.Interfaces;

namespace ChatbotIaJuridico.Services.Services
{
    public class PreInsumoServices : IPreInsumoServices
    {
        protected readonly IPreInsumo _repository;

        public PreInsumoServices(IPreInsumo repository)
        {
            _repository = repository;
        }

        public async Task<List<PreInsumo>> getAllAsync()
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

        public async Task<PreInsumo> getByIdAsync(int id)
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

        public async Task<PreInsumo> getLastPreInsumoWithTypeCpf(Advogado advogado)
        {
            try
            {
                return await _repository.getLastPreInsumoWithTypeCpf(advogado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PreInsumo> getLastPreInsumoWithTypeIdPreProcesso(Advogado advogado)
        {
            try
            {
                return await _repository.getLastPreInsumoWithTypeIdPreProcesso(advogado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PreInsumo> createAsync(PreInsumo model)
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

        public async Task<PreInsumo> updateAsync(PreInsumo model)
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

        public async Task<PreInsumo> deleteAsync(PreInsumo model)
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

        public async Task<PreInsumo> getLastPreInsumoWithNotIsTypeIdPreProcessoOrCpf(Advogado advogado)
        {
            try
            {
                return await _repository.getLastPreInsumoWithNotIsTypeIdPreProcessoOrCpf(advogado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PreInsumo> getLastPreInsumo()
        {
            try
            {
                return await _repository.getLastPreInsumo();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> checkInsumoRepetido(string waId)
        {
            try
            {
                return await _repository.checkInsumoRepetido(waId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<PreInsumo> SalvarPreInsumo(ContentDocument ContentDocument, Chat chat, Advogado advogado, ETipoRecebimentoMensagem tipo)
        {
            var preInsumo = new PreInsumo
            {
                pInsDescricao = ContentDocument.Descricao.Replace(".","").Replace("-", ""),
                pInsWaid = ContentDocument.WaId,
                pInsCaminho = ContentDocument.Caminho,
                pInsTipo = PreInsumo.MapearTipoPreInsumo(tipo),
                AdvId = advogado.AdvId,
                ChaId = chat.ChaId,
                pInsDataModificacao = DateTime.Now,
                pInsData = DateTime.Now
            };

            await createAsync(preInsumo);

            return preInsumo;
        }

        public async Task<PreInsumo> getLastPreInsumoWithImplicityType(Advogado advogado, ETipoPreInsumo type)
        {
            try
            {
                return await _repository.getLastPreInsumoWithImplicityType(advogado, type);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
