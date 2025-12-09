using ChatbotIaJuridico.Infra;
using ChatbotIaJuridico.Services.Dtto;

namespace ChatbotIaJuridico.Services.Interfaces
{
    public interface IAdvogadoServices : IBaseInterfaceServices<AdvogadoDtto>
    {
        public Task<List<AdvogadoDtto.AdvogadoDttoGetForView>> getAllDttoForViewAsync();
        public Task<Advogado> getAdvogadoByWaId(string waId);
    }
}
