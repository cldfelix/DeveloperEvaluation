using FluentValidation;

namespace DeveloperEvaluation.WebApi.Features.PessoaJuridica.Get;

public class GetPessoaJuridicaRequestValidator : AbstractValidator<GetPessoaJuridicaRequest>
{
    public GetPessoaJuridicaRequestValidator()
    {
        RuleFor(p => p.Id).
            NotEmpty().
            WithMessage("Campo obrigatorio");

    }
}