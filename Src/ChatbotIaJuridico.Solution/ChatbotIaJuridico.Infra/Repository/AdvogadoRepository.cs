using ChatbotIaJuridico.Infra.DAL;
using ChatbotIaJuridico.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatbotIaJuridico.Infra.Repository
{
    public class AdvogadoRepository : BaseRepository<Advogado>, IAdvogadoInterface
    {
        public AdvogadoRepository(ChatbotIaJuridicoContext context) : base(context)
        {
        }

        public async Task<List<Advogado>> getAllAsync() => await GetAllAsync();
        public async Task<Advogado> getByIdAsync(int id) => await GetByIdAsync(id);
        public async Task<Advogado> getAdvogadoByWaId(string Waid) => await _context.Set<Advogado>().Include(x => x.Clientes).Include(x => x.Chats).Include(x => x.PreProcessos).FirstOrDefaultAsync(x => x.AdvWaid == Waid);
        public async Task<Advogado> createAsync(Advogado model) => await CreateAsync(model);
        public async Task<Advogado> updateAsync(Advogado model) => await UpdateAsync(model);
        public async Task<Advogado> deleteAsync(Advogado model) => await DeleteAsync(model);        

    }
}
