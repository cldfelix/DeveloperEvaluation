using AutoMapper;
using DeveloperEvaluation.Application.PessoaJuridica.Get;
using DeveloperEvaluation.WebApi.Features.PessoaJuridica.Delete;

namespace DeveloperEvaluation.WebApi.Features.PessoaJuridica.Get;

public class GetPessoaJuridicaProfiler : Profile
{
    public GetPessoaJuridicaProfiler()
    {
        CreateMap<GetPessoaJuridicaRequest, GetPessoaJuridicaCommand>();
        CreateMap<GetPessoaJuridicaResult, GetPessoaJuridicaResponse>();
    }
}