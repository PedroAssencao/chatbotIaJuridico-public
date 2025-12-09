namespace ChatbotIaJuridico.Infra.Interfaces
{
    public interface IAdvogadoInterface : IBaseInterface<Advogado>
    {
        public Task<Advogado> getAdvogadoByWaId(string waId);
    }
}
