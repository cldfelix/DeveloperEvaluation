using FluentValidation;

namespace DeveloperEvaluation.WebApi.Features.PessoaFisica.Delete;

public class DeletePessoaFisicaRequestValidator : AbstractValidator<DeletePessoaFisicaRequest>
{
    public DeletePessoaFisicaRequestValidator()
    {
        RuleFor(p => p.Cpf).Length(11).WithMessage("Camppo obrigatorio no formato xxxxxxxxxxx com 11 caracteres");

    }
}