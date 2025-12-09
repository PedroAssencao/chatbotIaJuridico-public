using ChatbotIaJuridico.Domain.Models.Enum;
using ChatbotIaJuridico.Infra.DAL;
using ChatbotIaJuridico.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatbotIaJuridico.Infra.Repository
{
    public class PreInsumoRepository : BaseRepository<PreInsumo>, IPreInsumo
    {
        public PreInsumoRepository(ChatbotIaJuridicoContext context) : base(context)
        {
        }

        public async Task<List<PreInsumo>> getAllAsync() => await GetAllAsync();

        public async Task<PreInsumo> getByIdAsync(int id) => await GetByIdAsync(id);

        public async Task<PreInsumo> getLastPreInsumoWithTypeCpf(Advogado advogado) => await _context.Set<PreInsumo>().OrderByDescending(x => x.pInsDataModificacao).FirstOrDefaultAsync(x => x.pInsTipo == ETipoPreInsumo.cpf && x.AdvId == advogado.AdvId);

        public async Task<PreInsumo> getLastPreInsumoWithTypeIdPreProcesso(Advogado advogado) => await _context.Set<PreInsumo>().OrderByDescending(x => x.pInsDataModificacao).FirstOrDefaultAsync(x => x.pInsTipo == ETipoPreInsumo.idPreProcesso && x.AdvId == advogado.AdvId);

        public async Task<PreInsumo> createAsync(PreInsumo model) => await CreateAsync(model);

        public async Task<PreInsumo> updateAsync(PreInsumo model) => await UpdateAsync(model);

        public async Task<PreInsumo> deleteAsync(PreInsumo model) => await DeleteAsync(model);

        public async Task<PreInsumo> getLastPreInsumoWithNotIsTypeIdPreProcessoOrCpf(Advogado advogado) => await _context.Set<PreInsumo>().OrderByDescending(x => x.pInsDataModificacao).FirstOrDefaultAsync(x => x.AdvId == advogado.AdvId && x.pInsTipo != ETipoPreInsumo.cpf && x.pInsTipo != ETipoPreInsumo.descricaoDeResposta && x.pInsTipo != ETipoPreInsumo.idPreProcesso);

        public async Task<PreInsumo> getLastPreInsumo() => await _context.Set<PreInsumo>().OrderByDescending(x => x.pInsData).FirstOrDefaultAsync();

        public async Task<bool> checkInsumoRepetido(string waId) => await _context.Set<PreInsumo>().AnyAsync(x => x.pInsWaid == waId);

        public async Task<PreInsumo> getLastPreInsumoWithImplicityType(Advogado advogado, ETipoPreInsumo type) => await _context.Set<PreInsumo>().OrderByDescending(x => x.pInsDataModificacao).FirstOrDefaultAsync(x => x.pInsTipo == type);
    }
}
