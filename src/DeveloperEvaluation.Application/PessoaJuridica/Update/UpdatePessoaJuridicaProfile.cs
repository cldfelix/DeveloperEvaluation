using AutoMapper;
using DeveloperEvaluation.Application.PessoaJuridica.Create;

namespace DeveloperEvaluation.Application.PessoaJuridica.Update;

public class UpdatePessoaJuridicaProfile : Profile
{
    public UpdatePessoaJuridicaProfile()
    {
        CreateMap<UpdatePessoaJuridicaCommand, global::DeveloperEvaluation.Domain.Entities.PessoaJuridica>();
        CreateMap<global::DeveloperEvaluation.Domain.Entities.PessoaJuridica, UpdatePessoaJuridicaResult>();
    }
}