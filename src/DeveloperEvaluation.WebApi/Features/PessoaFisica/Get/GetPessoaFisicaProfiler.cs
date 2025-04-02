using AutoMapper;
using DeveloperEvaluation.Application.PessoaFisica.Get;
using DeveloperEvaluation.WebApi.Features.PessoaFisica.Delete;

namespace DeveloperEvaluation.WebApi.Features.PessoaFisica.Get;

public class GetPessoaFisicaProfiler : Profile
{
    public GetPessoaFisicaProfiler()
    {
        CreateMap<GetPessoaFisicaRequest, GetPessoaFisicaCommand>();
        CreateMap<GetPessoaFisicaResult, GetPessoaFisicaResponse>();
    }
}