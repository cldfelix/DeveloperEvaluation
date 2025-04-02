using AutoMapper;

namespace DeveloperEvaluation.Application.PessoaJuridica.Get;

public class GetPessoaJuridicaProfile : Profile
{
    public GetPessoaJuridicaProfile()
    {
        CreateMap<global::DeveloperEvaluation.Domain.Entities.PessoaJuridica, GetPessoaJuridicaResult>();
    }
}