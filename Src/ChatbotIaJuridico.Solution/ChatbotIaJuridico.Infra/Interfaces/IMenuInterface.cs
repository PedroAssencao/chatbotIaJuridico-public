using ChatbotIaJuridico.Domain.Models.Enum;

namespace ChatbotIaJuridico.Infra.Interfaces
{
    public interface IMenuInterface : IBaseInterface<Menu>
    {
        public Task<Menu> getMenuByType(ETipoMenu type);
    }
}
