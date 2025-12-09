using ChatbotIaJuridico.Domain.Models.Enum;
using ChatbotIaJuridico.Domain.Models.JsonMetaModels;
using ChatbotIaJuridico.Infra;

namespace ChatbotIaJuridico.Services.Interfaces
{
    public interface IPreInsumoServices : IBaseInterfaceServices<PreInsumo>
    {
        public Task<PreInsumo> getLastPreInsumo();
        public Task<bool> checkInsumoRepetido(string waId);
        public Task<PreInsumo> getLastPreInsumoWithTypeCpf(Advogado advogado);
        public Task<PreInsumo> getLastPreInsumoWithTypeIdPreProcesso(Advogado advogado);
        public Task<PreInsumo> getLastPreInsumoWithNotIsTypeIdPreProcessoOrCpf(Advogado advogado);
        public Task<PreInsumo> SalvarPreInsumo(ContentDocument ContentDocument, Chat chat, Advogado advogado, ETipoRecebimentoMensagem tipo);
        public Task<PreInsumo> getLastPreInsumoWithImplicityType(Advogado advogado, ETipoPreInsumo type);
    }
}
