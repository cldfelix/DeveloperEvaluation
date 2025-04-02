namespace DeveloperEvaluation.Application.PessoaJuridica.Create;

public class CreatePessoaJuridicaResult
{
    public Guid Id { get; set; }
    public string RazaoSocial { get; set; }
    public string? InscricaoEstadua { get; set; }
    public bool Isento { get; set; }
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