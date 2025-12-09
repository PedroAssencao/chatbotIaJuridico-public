using ChatbotIaJuridico.Infra;

namespace ChatbotIaJuridico.Services.Interfaces
{
    public interface IInsumoServices : IBaseInterfaceServices<Insumo>
    {
        public Task SalvarInsumo(PreInsumo PreInsumo, int pProcId);
    }
}
