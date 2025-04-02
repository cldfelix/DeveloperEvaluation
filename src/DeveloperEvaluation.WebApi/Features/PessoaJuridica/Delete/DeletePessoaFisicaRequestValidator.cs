using FluentValidation;

namespace DeveloperEvaluation.WebApi.Features.PessoaJuridica.Delete;

public class DeletePessoaJuridicaRequestValidator : AbstractValidator<DeletePessoaJuridicaRequest>
{
    public DeletePessoaJuridicaRequestValidator()
    {
        RuleFor(p => p. Id)
            .NotEmpty()
            .WithMessage("Campo obrigatorio");


    }
}