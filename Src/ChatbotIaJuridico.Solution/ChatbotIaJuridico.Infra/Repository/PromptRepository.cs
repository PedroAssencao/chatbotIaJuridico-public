using ChatbotIaJuridico.Infra.DAL;
using ChatbotIaJuridico.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatbotIaJuridico.Infra.Repository
{
    public class PromptRepository : BaseRepository<Prompt>, IPromptInterface
    {
        public PromptRepository(ChatbotIaJuridicoContext context) : base(context)
        {
        }

        public async Task<List<Prompt>> getAllAsync() => await GetAllAsync();

        public async Task<Prompt> getByIdAsync(int id) => await getByIdAsync(id);

        public async Task<Prompt> createAsync(Prompt model) => await CreateAsync(model);

        public async Task<Prompt> updateAsync(Prompt model) => await UpdateAsync(model);    

        public async Task<Prompt> deleteAsync(Prompt model) => await DeleteAsync(model);

        public async Task<Prompt> GetPromptByDesc(string desc) => await _context.Set<Prompt>().FirstOrDefaultAsync(x => x.PrompDescricao == desc);
    }
}
