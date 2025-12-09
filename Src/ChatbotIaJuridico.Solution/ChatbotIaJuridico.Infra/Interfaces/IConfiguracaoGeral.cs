namespace ChatbotIaJuridico.Infra.Interfaces
{
    public interface IConfiguracaoGeral : IBaseInterface<ConfiguracaoGeral>
    {
        public Task<ConfiguracaoGeral> getValueByDesc(string desc);
    }
}
