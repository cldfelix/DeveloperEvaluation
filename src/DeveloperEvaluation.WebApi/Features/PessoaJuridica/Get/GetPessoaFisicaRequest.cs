namespace DeveloperEvaluation.WebApi.Features.PessoaJuridica.Get;

public class GetPessoaJuridicaRequest
{
    public GetPessoaJuridicaRequest(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; private set; }
}

