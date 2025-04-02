using AutoMapper;
using DeveloperEvaluation.Application.PessoaJuridica.Get;

namespace DeveloperEvaluation.Application.PessoaJuridica.GetAll;

public class GetListPessoaJuridicaProfile : Profile
{
    public GetListPessoaJuridicaProfile()
    {
        CreateMap<IEnumerable<global::DeveloperEvaluation.Domain.Entities.PessoaJuridica>, GetListPessoaJuridicaResult>()
            .ForMember(dest => dest.ListPessoaJuridicaResults, opt => opt.MapFrom(src => src));       



    }
}