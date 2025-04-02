using AutoMapper;
using DeveloperEvaluation.Application.PessoaFisica.Update;

namespace DeveloperEvaluation.WebApi.Features.PessoaFisica.Update;

public class UpdatePessoaFisicaProfiler : Profile
{
    public UpdatePessoaFisicaProfiler()
    {
        CreateMap<UpdatePessoaFisicaRequest, UpdatePessoaFisicaCommand>();
        CreateMap<UpdatePessoaFisicaResult, UpdatePessoaFisicaResponse>();
    }
}