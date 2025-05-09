namespace DeveloperEvaluation.WebApi.Features.PessoaFisica.Update;

public class UpdatePessoaFisicaRequest
{
    public string Cpf { get; set; }
    public string Nome { get; set; }
    public string Cep { get; set; }
    public string Rua { get; set; }
    public string Numero { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public DateOnly DataNascimento { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
}

