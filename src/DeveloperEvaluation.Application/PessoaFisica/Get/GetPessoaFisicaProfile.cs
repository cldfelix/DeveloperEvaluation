using AutoMapper;

namespace DeveloperEvaluation.Application.PessoaFisica.Get;

public class GetPessoaFisicaProfile : Profile
{
    public GetPessoaFisicaProfile()
    {
        CreateMap<global::DeveloperEvaluation.Domain.Entities.PessoaFisica, GetPessoaFisicaResult>();
    }
}