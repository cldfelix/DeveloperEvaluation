using AutoMapper;
using DeveloperEvaluation.Application.PessoaFisica.Create;
using DeveloperEvaluation.WebApi.Features.PessoaFisica.Create;
using DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

namespace DeveloperEvaluation.WebApi.Mappings;

public class CreatePessoaFisicaRequestProfile : Profile
{
    public CreatePessoaFisicaRequestProfile()
    {
        CreateMap<CreatePessoaFisicaRequest, CreatePessoaFisicaCommand>();
        CreateMap<CreatePessoaFisicaResult, CreatePessoaFisicaResponse>();
    }

}