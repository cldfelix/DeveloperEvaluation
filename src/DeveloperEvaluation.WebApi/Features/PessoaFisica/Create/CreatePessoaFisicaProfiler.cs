using AutoMapper;
using DeveloperEvaluation.Application.PessoaFisica.Create;
using DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

namespace DeveloperEvaluation.WebApi.Features.PessoaFisica.Create;

public class CreatePessoaFisicaProfiler: Profile
{
    public CreatePessoaFisicaProfiler()
    {
        CreateMap<CreatePessoaFisicaRequest, CreatePessoaFisicaCommand>();
        CreateMap<CreatePessoaFisicaResult, CreatePessoaFisicaResponse>();
    }
}