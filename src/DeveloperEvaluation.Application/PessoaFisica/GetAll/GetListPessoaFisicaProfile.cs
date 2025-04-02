using AutoMapper;
using DeveloperEvaluation.Application.PessoaFisica.Get;

namespace DeveloperEvaluation.Application.PessoaFisica.GetAll;

public class GetListPessoaFisicaProfile : Profile
{
    public GetListPessoaFisicaProfile()
    {
        CreateMap<IEnumerable<global::Domain.Entities.PessoaFisica>, GetListPessoaFisicaResult>()
            .ForMember(dest => dest.ListPessoaFisicaResults, opt => opt.MapFrom(src => src));       



    }
}