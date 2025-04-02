using AutoMapper;
using DeveloperEvaluation.Application.PessoaJuridica.Create;
using DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

namespace DeveloperEvaluation.WebApi.Features.PessoaJuridica.Create;

public class CreatePessoaJuridicaProfiler: Profile
{
    public CreatePessoaJuridicaProfiler()
    {
        CreateMap<CreatePessoaJuridicaRequest, CreatePessoaJuridicaCommand>();
        CreateMap<CreatePessoaJuridicaResult, CreatePessoaJuridicaResponse>();
    }
}