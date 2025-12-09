using ChatbotIaJuridico.Infra;

namespace ChatbotIaJuridico.Services.Interfaces
{
    public interface IConfiguracaoGeralServices : IBaseInterfaceServices<ConfiguracaoGeral>
    {
        public Task<ConfiguracaoGeral> getValueByFild(string desc);
    }
}
