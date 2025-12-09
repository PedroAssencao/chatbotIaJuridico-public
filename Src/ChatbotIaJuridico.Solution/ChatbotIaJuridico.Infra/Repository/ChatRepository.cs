using ChatbotIaJuridico.Infra.DAL;
using ChatbotIaJuridico.Infra.Interfaces;

namespace ChatbotIaJuridico.Infra.Repository
{
    public class ChatRepository : BaseRepository<Chat>, IChatInterface
    {
        public ChatRepository(ChatbotIaJuridicoContext context) : base(context)
        {
        }

        public async Task<List<Chat>> getAllAsync() => await GetAllAsync();

        public async Task<Chat> getByIdAsync(int id) => await GetByIdAsync(id);

        public async Task<Chat> createAsync(Chat model) => await CreateAsync(model);

        public async Task<Chat> updateAsync(Chat model) => await UpdateAsync(model);

        public async Task<Chat> deleteAsync(Chat model) => await DeleteAsync(model);
    }
}
