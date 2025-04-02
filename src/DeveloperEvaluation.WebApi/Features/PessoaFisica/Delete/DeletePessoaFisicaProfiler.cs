using AutoMapper;
using DeveloperEvaluation.Application.PessoaFisica.Delete;
using DeveloperEvaluation.Application.PessoaFisica.Get;

namespace DeveloperEvaluation.WebApi.Features.PessoaFisica.Delete;

public class DeletePessoaFisicaProfiler : Profile
{
    public DeletePessoaFisicaProfiler()
    {
        CreateMap<DeletePessoaFisicaRequest, DeletePessoaFisicaCommand>();
    }
}