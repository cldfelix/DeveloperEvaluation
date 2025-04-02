namespace DeveloperEvaluation.WebApi.Features.PessoaJuridica.Delete;

public class DeletePessoaJuridicaRequest
{
    public DeletePessoaJuridicaRequest(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; private set; }
}

