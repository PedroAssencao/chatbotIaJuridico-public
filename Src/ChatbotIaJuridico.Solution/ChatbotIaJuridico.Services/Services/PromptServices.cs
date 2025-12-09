using ChatbotIaJuridico.Infra;
using ChatbotIaJuridico.Infra.Interfaces;
using ChatbotIaJuridico.Services.Interfaces;
using System.Net.Http.Headers;

namespace ChatbotIaJuridico.Services.Services
{
    public class PromptServices : IPromptInterfaceServices
    {
        protected readonly IPromptInterface _prompt;

        public PromptServices(IPromptInterface prompt)
        {
            _prompt = prompt;
        }

        public async Task<List<Prompt>> getAllAsync()
        {
            try
            {
                return await _prompt.getAllAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Prompt> getByIdAsync(int id)
        {
            try
            {
                return await _prompt.getByIdAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Prompt> createAsync(Prompt model)
        {
            try
            {
                return await _prompt.createAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Prompt> updateAsync(Prompt model)
        {
            try
            {
                return await _prompt.updateAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Prompt> deleteAsync(Prompt model)
        {
            try
            {
                return await _prompt.deleteAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Prompt> GetPromptByDesc(string desc)
        {
            try
            {
                return await _prompt.GetPromptByDesc(desc);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
