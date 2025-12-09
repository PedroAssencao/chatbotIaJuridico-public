using ChatbotIaJuridico.Infra;
using ChatbotIaJuridico.Infra.Interfaces;
using ChatbotIaJuridico.Services.Interfaces;

namespace ChatbotIaJuridico.Services.Services
{
    public class InsumoServices : IInsumoServices
    {
        protected readonly IInsumoInterface _insumoInterface;        

        public InsumoServices(IInsumoInterface insumoInterface)
        {
            _insumoInterface = insumoInterface;
        }

        public async Task<List<Insumo>> getAllAsync()
        {
            try
            {
                return await _insumoInterface.getAllAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Insumo> getByIdAsync(int id)
        {
            try
            {
                return await _insumoInterface.getByIdAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Insumo> createAsync(Insumo model)
        {
            try
            {
                return await _insumoInterface.createAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Insumo> updateAsync(Insumo model)
        {
            try
            {
                return await _insumoInterface.updateAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Insumo> deleteAsync(Insumo model)
        {
            try
            {
                return await _insumoInterface.deleteAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SalvarInsumo(PreInsumo PreInsumo, int pProcId)
        {
            var InsumoModel = new Insumo
            {
                InsDescricao = PreInsumo.pInsDescricao,
                InsWaid = PreInsumo.pInsWaid,
                InsCaminho = PreInsumo.pInsCaminho,
                InsTipo = Insumo.MapearTipoInsumo(PreInsumo.pInsTipo),
                AdvId = PreInsumo.AdvId,
                ChaId = PreInsumo.ChaId,
                InsData = DateTime.Now,
                PProcId = pProcId
            };

            await createAsync(InsumoModel);
        }

    }
}
