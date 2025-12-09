using AutoMapper;
using ChatbotIaJuridico.Infra;
using ChatbotIaJuridico.Infra.Interfaces;
using ChatbotIaJuridico.Services.Dtto;
using ChatbotIaJuridico.Services.Interfaces;

namespace ChatbotIaJuridico.Services.Services
{
    public class AdvogadoServcies : IAdvogadoServices
    {
        protected readonly IAdvogadoInterface _repository;
        private readonly IMapper _mapper;

        public AdvogadoServcies(IAdvogadoInterface repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AdvogadoDtto.AdvogadoDttoGetForView>> getAllDttoForViewAsync()
        {
            try
            {
                var result = await _repository.getAllAsync();
                var list = _mapper.Map<List<AdvogadoDtto.AdvogadoDttoGetForView>>(result);
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Task<AdvogadoDtto> createAsync(AdvogadoDtto model)
        {
            throw new NotImplementedException();
        }

        public Task<AdvogadoDtto> deleteAsync(AdvogadoDtto model)
        {
            throw new NotImplementedException();
        }

        public Task<List<AdvogadoDtto>> getAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AdvogadoDtto> getByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AdvogadoDtto> updateAsync(AdvogadoDtto model)
        {
            throw new NotImplementedException();
        }

        public async Task<Advogado> getAdvogadoByWaId(string waId) => await _repository.getAdvogadoByWaId(waId);
    }
}
