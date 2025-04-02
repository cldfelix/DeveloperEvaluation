using AutoMapper;

namespace DeveloperEvaluation.Application.PessoaFisica.Create;

public class UpdatePessoaFisicaProfile : Profile
{
    public UpdatePessoaFisicaProfile()
    {
        CreateMap<CreatePessoaFisicaCommand, global::Domain.Entities.PessoaFisica>();
        CreateMap<global::Domain.Entities.PessoaFisica, CreatePessoaFisicaResult>();
    }
}