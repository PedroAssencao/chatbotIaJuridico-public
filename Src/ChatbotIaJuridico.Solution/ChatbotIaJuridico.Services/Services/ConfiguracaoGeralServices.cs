using System.Net.Http.Headers;
using ChatbotIaJuridico.Infra;
using ChatbotIaJuridico.Infra.Interfaces;
using ChatbotIaJuridico.Services.Interfaces;

namespace ChatbotIaJuridico.Services.Services
{
    public class ConfiguracaoGeralServices : IConfiguracaoGeralServices
    {
        protected readonly IConfiguracaoGeral _configuracaoGeral;

        public ConfiguracaoGeralServices(IConfiguracaoGeral configuracaoGeral)
        {
            _configuracaoGeral = configuracaoGeral;
        }

        public async Task<List<ConfiguracaoGeral>> getAllAsync()
        {
            return await _configuracaoGeral.getAllAsync();
        }
        public async Task<ConfiguracaoGeral> getByIdAsync(int id)
        {
            return await _configuracaoGeral.getByIdAsync(id);
        }
        public async Task<ConfiguracaoGeral> createAsync(ConfiguracaoGeral model)
        {
            return await _configuracaoGeral.createAsync(model);
        }
        public async Task<ConfiguracaoGeral> updateAsync(ConfiguracaoGeral model)
        {
            return await _configuracaoGeral.updateAsync(model);
        }
        public async Task<ConfiguracaoGeral> deleteAsync(ConfiguracaoGeral model)
        {
            return await _configuracaoGeral.deleteAsync(model);
        }

        public async Task<ConfiguracaoGeral> getValueByFild(string desc)
        {
            return await _configuracaoGeral.getValueByDesc(desc);
        }
    }
}
