using DeveloperEvaluation.Application.PessoaJuridica.Get;
using DeveloperEvaluation.WebApi.Features.PessoaJuridica.Delete;
using DeveloperEvaluation.WebApi.Features.PessoaJuridica.Get;

namespace DeveloperEvaluation.WebApi.Features.PessoaJuridica.GetAll;

public class GetListPessoaJuridicaResponse
{
    public IEnumerable<GetPessoaJuridicaResponse> ListPessoaJuridicaResults { get; set; }
}