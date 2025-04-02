namespace DeveloperEvaluation.WebApi.Features.PessoaFisica.Delete;

public class DeletePessoaFisicaRequest
{
    public DeletePessoaFisicaRequest(string cpf)
    {
        Cpf = cpf;
    }
    public string Cpf { get; private set; }
}

