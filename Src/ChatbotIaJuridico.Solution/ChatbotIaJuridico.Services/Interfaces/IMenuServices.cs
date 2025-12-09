using ChatbotIaJuridico.Domain.Models.Enum;
using ChatbotIaJuridico.Infra;

namespace ChatbotIaJuridico.Services.Interfaces
{
    public interface IMenuServices : IBaseInterfaceServices<Menu>
    {
        public Task<Menu> getMenuByType(ETipoMenu type);    
    }
}
