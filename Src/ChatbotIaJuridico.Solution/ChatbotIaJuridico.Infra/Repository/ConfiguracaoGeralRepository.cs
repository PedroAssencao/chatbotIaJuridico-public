using ChatbotIaJuridico.Infra.DAL;
using ChatbotIaJuridico.Infra.Interfaces;

namespace ChatbotIaJuridico.Infra.Repository
{
    public class ConfiguracaoGeralRepository : BaseRepository<ConfiguracaoGeral>, IConfiguracaoGeral
    {
        public ConfiguracaoGeralRepository(ChatbotIaJuridicoContext context) : base(context)
        {
        }

        public async Task<List<ConfiguracaoGeral>> getAllAsync() => await GetAllAsync();
        public async Task<ConfiguracaoGeral> getByIdAsync(int id) => await GetByIdAsync(id);
        public async Task<ConfiguracaoGeral> createAsync(ConfiguracaoGeral model) => await CreateAsync(model);
        public async Task<ConfiguracaoGeral> updateAsync(ConfiguracaoGeral model) => await UpdateAsync(model);
        public async Task<ConfiguracaoGeral> deleteAsync(ConfiguracaoGeral model) => await DeleteAsync(model);

        public async Task<ConfiguracaoGeral> getValueByDesc(string desc)
        {
            var dados = await GetAllAsync();
            return dados.FirstOrDefault(x => x.ConfDescricao == desc);
        }
    }
}
