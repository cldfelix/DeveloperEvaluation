using AutoMapper;
using DeveloperEvaluation.Application.PessoaJuridica.Update;

namespace DeveloperEvaluation.WebApi.Features.PessoaJuridica.Update;

public class UpdatePessoaJuridicaProfiler : Profile
{
    public UpdatePessoaJuridicaProfiler()
    {
        CreateMap<UpdatePessoaJuridicaRequest, UpdatePessoaJuridicaCommand>();
        CreateMap<UpdatePessoaJuridicaResult, UpdatePessoaJuridicaResponse>();
    }
}