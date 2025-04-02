using FluentValidation;

namespace DeveloperEvaluation.WebApi.Features.PessoaFisica.Get;

public class GetPessoaFisicaRequestValidator : AbstractValidator<GetPessoaFisicaRequest>
{
    public GetPessoaFisicaRequestValidator()
    {
        RuleFor(p => p.Cpf).Length(11).WithMessage("Camppo obrigatorio no formato xxxxxxxxxxx com 11 caracteres");

    }
}