using AutoMapper;
using DeveloperEvaluation.Application.PessoaJuridica.Get;
using DeveloperEvaluation.Application.PessoaJuridica.GetAll;

namespace DeveloperEvaluation.WebApi.Features.PessoaJuridica.GetAll;

public class GetListPessoaJuridicaProfiler : Profile
{
    public GetListPessoaJuridicaProfiler()
    {
        CreateMap<GetListPessoaJuridicaRequest, GetListPessoaJuridicaComand>();
        CreateMap<GetListPessoaJuridicaResult, GetListPessoaJuridicaResponse>();



    }
}