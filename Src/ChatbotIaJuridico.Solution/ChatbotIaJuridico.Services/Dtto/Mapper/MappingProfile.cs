using AutoMapper;
using ChatbotIaJuridico.Infra;
using ChatbotIaJuridico.Services.Dtto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Advogado, AdvogadoDtto>();
        CreateMap<AdvogadoDtto, Advogado>();
        CreateMap<Advogado, AdvogadoDtto.AdvogadoDttoGetForView>()
            .ForMember(dest => dest.CodigoAdvogado, opt => opt.MapFrom(src => src.AdvId))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.AdvNome))
            .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.maskCpf()))
            .ForMember(dest => dest.NumeroWhatsapp, opt => opt.MapFrom(src => src.AdvWaid));
    }
}