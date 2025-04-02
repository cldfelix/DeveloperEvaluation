using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperEvaluation.Application.PessoaFisica.Create;
using FluentValidation;

namespace DeveloperEvaluation.Application.PessoaFisica.Get
{
    public class GetPessoaFisicaValidator : AbstractValidator<GetPessoaFisicaCommand>
    {
        public GetPessoaFisicaValidator()
        {
            RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage("Cpf is required");
        }
    }
}
