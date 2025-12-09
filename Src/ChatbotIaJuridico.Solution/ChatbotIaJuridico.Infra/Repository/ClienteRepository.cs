using ChatbotIaJuridico.Infra.DAL;
using ChatbotIaJuridico.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatbotIaJuridico.Infra.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClientInterface
    {
        public ClienteRepository(ChatbotIaJuridicoContext context) : base(context)
        {
        }

        public async Task<List<Cliente>> getAllAsync() => await GetAllAsync();
        public async Task<Cliente> getByIdAsync(int id) => await GetByIdAsync(id);
        public async Task<Cliente> createAsync(Cliente model) => await CreateAsync(model);
        public async Task<Cliente> updateAsync(Cliente model) => await UpdateAsync(model);
        public async Task<Cliente> deleteAsync(Cliente model) => await DeleteAsync(model);
        public async Task<Cliente> getLastClientCreateByAdvgadoAsync(Advogado advogado)
        {
            return await _context.Set<Cliente>()
                .Where(x => x.AdvId == advogado.AdvId)
                .OrderByDescending(x => x.CliDataCriacao)
                .FirstOrDefaultAsync();
        }
        public async Task<List<Cliente>> getTopEightLastClienteUpdates(Advogado advogado)
        {
            return await _context.Set<Cliente>()
                .Where(x => x.AdvId == advogado.AdvId)
                .OrderByDescending(x => x.CliDataModificacao)
                .Take(8)
                .ToListAsync();
        }

        public async Task<Cliente> getClienteByCpfOrName(Advogado advogado, string content)
        {
            return await _context.Set<Cliente>().Where(x => x.AdvId == advogado.AdvId && (x.CliCpf == content || x.CliNome.Contains(content)))
                .FirstOrDefaultAsync();
        }

        public async Task updateDataModificacao(Cliente cliente)
        {
            cliente.CliDataModificacao = DateTime.Now;
            _context.Set<Cliente>().Update(cliente);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task<Cliente> getLastClientModfiedByAdvgadoAsync(Advogado advogado)
        {
            return await _context.Set<Cliente>()
                .Where(x => x.AdvId == advogado.AdvId)
                .OrderByDescending(x => x.CliDataModificacao)
                .FirstOrDefaultAsync();
        }
    }
}
