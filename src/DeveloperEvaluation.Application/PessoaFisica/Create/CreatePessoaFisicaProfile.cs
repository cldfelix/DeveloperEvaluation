using AutoMapper;

namespace DeveloperEvaluation.Application.PessoaFisica.Create;

public class UpdatePessoaFisicaProfile : Profile
{
    public UpdatePessoaFisicaProfile()
    {
        CreateMap<CreatePessoaFisicaCommand, global::DeveloperEvaluation.Domain.Entities.PessoaFisica>();
        CreateMap<global::DeveloperEvaluation.Domain.Entities.PessoaFisica, CreatePessoaFisicaResult>();
    }
}