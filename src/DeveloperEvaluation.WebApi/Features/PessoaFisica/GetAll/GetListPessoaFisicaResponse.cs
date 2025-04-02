using DeveloperEvaluation.Application.PessoaFisica.Get;
using DeveloperEvaluation.WebApi.Features.PessoaFisica.Delete;
using DeveloperEvaluation.WebApi.Features.PessoaFisica.Get;

namespace DeveloperEvaluation.WebApi.Features.PessoaFisica.GetAll;

public class GetListPessoaFisicaResponse
{
    public IEnumerable<GetPessoaFisicaResponse> ListPessoaFisicaResults { get; set; }
}