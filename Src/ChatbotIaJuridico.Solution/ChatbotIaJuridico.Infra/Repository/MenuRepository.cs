using ChatbotIaJuridico.Domain.Models.Enum;
using ChatbotIaJuridico.Infra.DAL;
using ChatbotIaJuridico.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatbotIaJuridico.Infra.Repository
{
    public class MenuRepository : BaseRepository<Menu>, IMenuInterface
    {
        public MenuRepository(ChatbotIaJuridicoContext context) : base(context)
        {
        }
        public async Task<List<Menu>> getAllAsync() => await GetAllAsync();

        public async Task<Menu> getByIdAsync(int id) => await GetByIdAsync(id);

        public async Task<Menu> getMenuByType(ETipoMenu type) => await _context.Set<Menu>().Include(x => x.Options).AsNoTracking().FirstOrDefaultAsync(x => x.MenTipo == type);

        public async Task<Menu> createAsync(Menu model) => await CreateAsync(model);        

        public async Task<Menu> updateAsync(Menu model) => await UpdateAsync(model);

        public async Task<Menu> deleteAsync(Menu model) => await DeleteAsync(model);

    }
}
