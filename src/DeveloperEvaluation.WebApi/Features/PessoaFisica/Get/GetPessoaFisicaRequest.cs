namespace DeveloperEvaluation.WebApi.Features.PessoaFisica.Get;

public class GetPessoaFisicaRequest
{
    public GetPessoaFisicaRequest(string cpf)
    {
        Cpf = cpf;
    }
    public string Cpf { get; private set; }
}

