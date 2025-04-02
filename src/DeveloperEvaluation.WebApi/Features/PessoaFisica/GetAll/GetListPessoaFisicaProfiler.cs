using AutoMapper;
using DeveloperEvaluation.Application.PessoaFisica.Get;
using DeveloperEvaluation.Application.PessoaFisica.GetAll;

namespace DeveloperEvaluation.WebApi.Features.PessoaFisica.GetAll;

public class GetListPessoaFisicaProfiler : Profile
{
    public GetListPessoaFisicaProfiler()
    {
        CreateMap<GetListPessoaFisicaRequest, GetListPessoaFisicaComand>();
        CreateMap<GetListPessoaFisicaResult, GetListPessoaFisicaResponse>();



    }
}