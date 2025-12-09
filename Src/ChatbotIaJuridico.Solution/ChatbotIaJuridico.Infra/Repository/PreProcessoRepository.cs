using ChatbotIaJuridico.Infra.DAL;
using ChatbotIaJuridico.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatbotIaJuridico.Infra.Repository
{
    public class PreProcessoRepository : BaseRepository<PreProcesso>, IPreProcessoInterface
    {
        public PreProcessoRepository(ChatbotIaJuridicoContext context) : base(context)
        {
        }

        public async Task<List<PreProcesso>> getAllAsync() => await GetAllAsync();
        public async Task<PreProcesso> getByIdAsync(int id) => await GetByIdAsync(id);
        public async Task<PreProcesso> getLastPreProcessoCreateByAdvgadoAsync(Advogado advogado) => await _context.Set<PreProcesso>().Where(x => x.AdvId == advogado.AdvId).OrderByDescending(x => x.PProcDataCriacao).FirstOrDefaultAsync();
        public async Task<PreProcesso> createAsync(PreProcesso model) => await CreateAsync(model);
        public async Task<PreProcesso> updateAsync(PreProcesso model) => await UpdateAsync(model);
        public async Task<PreProcesso> deleteAsync(PreProcesso model) => await DeleteAsync(model);
        public async Task<List<PreProcesso>> getTopEightLastPreProcessoUpdates(Advogado advogado, Cliente cliente)
        {
            return await _context.Set<PreProcesso>()
                .Where(x => x.AdvId == advogado.AdvId && x.CliId == cliente.CliId)
                .OrderByDescending(x => x.PProcDataModificacao)
                .Take(8)
                .ToListAsync();
        }

        public async Task<PreProcesso> getPreProcessoByCodigoOuNome(Advogado advogado, string content)
        {
            bool isContentNumeric = int.TryParse(content, out int contentAsInt);

            return await _context.Set<PreProcesso>()
                .Where(x => x.AdvId == advogado.AdvId &&
                            (isContentNumeric ? x.PProcId == contentAsInt : x.PProcNome.Contains(content)))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Insumo>> getAllInsumoByPreProcesso(PreProcesso preProcesso)
        {
            var dados = await _context.Set<PreProcesso>().Include(x => x.Insumos).FirstOrDefaultAsync(x => x.PProcId == preProcesso.PProcId);
            return dados.Insumos.ToList();
        }
    }
}
