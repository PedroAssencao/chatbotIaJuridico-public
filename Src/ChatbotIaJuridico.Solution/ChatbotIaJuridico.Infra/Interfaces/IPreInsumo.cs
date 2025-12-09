using ChatbotIaJuridico.Domain.Models.Enum;

namespace ChatbotIaJuridico.Infra.Interfaces
{
    public interface IPreInsumo : IBaseInterface<PreInsumo>
    {
        public Task<PreInsumo> getLastPreInsumo();
        public Task<bool> checkInsumoRepetido(string waId);
        public Task<PreInsumo> getLastPreInsumoWithTypeCpf(Advogado advogado);
        public Task<PreInsumo> getLastPreInsumoWithTypeIdPreProcesso(Advogado advogado);
        public Task<PreInsumo> getLastPreInsumoWithNotIsTypeIdPreProcessoOrCpf(Advogado advogado);
        public Task<PreInsumo> getLastPreInsumoWithImplicityType(Advogado advogado, ETipoPreInsumo type);
    }
}
