using DeveloperEvaluation.Common.Validation;
using MediatR;

namespace DeveloperEvaluation.Application.PessoaFisica.Update;

public class UpdatePessoaFisicaCommand : IRequest<UpdatePessoaFisicaResult>
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



    public ValidationResultDetail Validate()
    {
        var validator = new UpdatePessoaFisicaCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}