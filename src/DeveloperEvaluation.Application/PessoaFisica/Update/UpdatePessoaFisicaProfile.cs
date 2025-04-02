using AutoMapper;
using DeveloperEvaluation.Application.PessoaFisica.Create;

namespace DeveloperEvaluation.Application.PessoaFisica.Update;

public class UpdatePessoaFisicaProfile : Profile
{
    public UpdatePessoaFisicaProfile()
    {
        CreateMap<UpdatePessoaFisicaCommand, global::Domain.Entities.PessoaFisica>();
        CreateMap<global::Domain.Entities.PessoaFisica, UpdatePessoaFisicaResult>();
    }
}