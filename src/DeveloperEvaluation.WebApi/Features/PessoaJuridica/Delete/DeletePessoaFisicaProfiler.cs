using AutoMapper;
using DeveloperEvaluation.Application.PessoaJuridica.Delete;
using DeveloperEvaluation.Application.PessoaJuridica.Get;

namespace DeveloperEvaluation.WebApi.Features.PessoaJuridica.Delete;

public class DeletePessoaJuridicaProfiler : Profile
{
    public DeletePessoaJuridicaProfiler()
    {
        CreateMap<DeletePessoaJuridicaRequest, DeletePessoaJuridicaCommand>();
    }
}