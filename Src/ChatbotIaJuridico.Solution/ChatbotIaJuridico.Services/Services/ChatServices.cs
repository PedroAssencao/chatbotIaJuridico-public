using ChatbotIaJuridico.Domain.Models.Enum;
using ChatbotIaJuridico.Infra;
using ChatbotIaJuridico.Infra.Interfaces;
using ChatbotIaJuridico.Services.Interfaces;

namespace ChatbotIaJuridico.Services.Services
{
    public class ChatServices : IChatInterfaceServices
    {
        protected readonly IChatInterface _chatInterface;

        public ChatServices(IChatInterface chatInterface)
        {
            _chatInterface = chatInterface;
        }
        public async Task<List<Chat>> getAllAsync()
        {
            try
            {
                return await _chatInterface.getAllAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Chat> ObterOuCriarChat(Advogado advogado)
        {
            var chat = advogado.Chats.FirstOrDefault();

            if (chat == null)
            {
                chat = await createAsync(new Chat
                {
                    AdvId = advogado.AdvId,
                    ChaEstado = EChatEstado.Envio
                });
                advogado.Chats.Add(chat);
            }
            return chat;
        }
        public async Task<Chat> getByIdAsync(int id)
        {
            try
            {
                return await _chatInterface.getByIdAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Chat> createAsync(Chat model)
        {
            try
            {
                return await _chatInterface.createAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Chat> updateAsync(Chat model)
        {
            try
            {
                return await _chatInterface.updateAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Chat> deleteAsync(Chat model)
        {
            try
            {
                return await _chatInterface.deleteAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
