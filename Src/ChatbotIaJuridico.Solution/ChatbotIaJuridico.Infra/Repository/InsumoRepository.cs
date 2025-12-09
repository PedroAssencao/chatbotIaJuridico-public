using ChatbotIaJuridico.Infra.DAL;
using ChatbotIaJuridico.Infra.Interfaces;

namespace ChatbotIaJuridico.Infra.Repository
{
    public class InsumoRepository : BaseRepository<Insumo>, IInsumoInterface
    {
        public InsumoRepository(ChatbotIaJuridicoContext context) : base(context)
        {
        }

        public async Task<List<Insumo>> getAllAsync() => await GetAllAsync();

        public async Task<Insumo> getByIdAsync(int id) => await GetByIdAsync(id);

        public async Task<Insumo> createAsync(Insumo model) => await CreateAsync(model);

        public async Task<Insumo> updateAsync(Insumo model) => await UpdateAsync(model);        

        public async Task<Insumo> deleteAsync(Insumo model) => await DeleteAsync(model);    

    }
}
