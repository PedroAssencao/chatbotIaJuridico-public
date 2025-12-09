using ChatbotIaJuridico.Infra;

namespace ChatbotIaJuridico.Services.Interfaces
{
    public interface IPromptInterfaceServices : IBaseInterfaceServices<Prompt>
    {
        public Task<Prompt> GetPromptByDesc(string desc);
    }
}
