namespace ChatbotIaJuridico.Infra.Interfaces
{
    public interface IPromptInterface : IBaseInterface<Prompt>
    {
        public Task<Prompt> GetPromptByDesc(string desc);
    }
}
