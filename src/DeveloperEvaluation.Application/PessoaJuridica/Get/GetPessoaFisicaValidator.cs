using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperEvaluation.Application.PessoaJuridica.Create;
using FluentValidation;

namespace DeveloperEvaluation.Application.PessoaJuridica.Get
{
    public class GetPessoaJuridicaValidator : AbstractValidator<GetPessoaJuridicaCommand>
    {
        public GetPessoaJuridicaValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Cpf is required");
        }
    }
}
