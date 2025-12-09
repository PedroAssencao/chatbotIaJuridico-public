using ChatbotIaJuridico.Domain.Models.Enum;
using ChatbotIaJuridico.Infra;
using ChatbotIaJuridico.Infra.Interfaces;
using ChatbotIaJuridico.Services.Interfaces;

namespace ChatbotIaJuridico.Services.Services
{
    public class MenuServices : IMenuServices
    {
        protected readonly IMenuInterface _repository;

        public MenuServices(IMenuInterface repository)
        {
            _repository = repository;
        }

        public async Task<List<Menu>> getAllAsync()
        {
            try
            {
                return await _repository.getAllAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Menu> getByIdAsync(int id)
        {
            try
            {
                return await _repository.getByIdAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Menu> getMenuByType(ETipoMenu type)
        {
            try
            {
                return await _repository.getMenuByType(type);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Menu> createAsync(Menu model)
        {
            try
            {
                return await _repository.createAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Menu> updateAsync(Menu model)
        {
            try
            {
                return await _repository.updateAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Menu> deleteAsync(Menu model)
        {
            try
            {
                return await _repository.deleteAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
