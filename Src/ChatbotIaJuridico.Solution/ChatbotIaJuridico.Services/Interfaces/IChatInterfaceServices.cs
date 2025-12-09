using ChatbotIaJuridico.Infra;

namespace ChatbotIaJuridico.Services.Interfaces
{
    public interface IChatInterfaceServices : IBaseInterfaceServices<Chat>
    {
        public Task<Chat> ObterOuCriarChat(Advogado advogado);
    }
}
