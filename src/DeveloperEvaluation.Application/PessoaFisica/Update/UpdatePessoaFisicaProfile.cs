using AutoMapper;
using DeveloperEvaluation.Application.PessoaFisica.Create;

namespace DeveloperEvaluation.Application.PessoaFisica.Update;

public class UpdatePessoaFisicaProfile : Profile
{
    public UpdatePessoaFisicaProfile()
    {
        CreateMap<UpdatePessoaFisicaCommand, global::DeveloperEvaluation.Domain.Entities.PessoaFisica>();
        CreateMap<global::DeveloperEvaluation.Domain.Entities.PessoaFisica, UpdatePessoaFisicaResult>();
    }
}