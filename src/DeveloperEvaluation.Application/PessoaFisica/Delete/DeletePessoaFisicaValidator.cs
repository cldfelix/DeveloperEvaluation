using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperEvaluation.Application.PessoaFisica.Create;
using DeveloperEvaluation.Application.PessoaFisica.Delete;
using FluentValidation;

namespace DeveloperEvaluation.Application.PessoaFisica.Get
{
    public class DeletePessoaFisicaValidator : AbstractValidator<DeletePessoaFisicaCommand>
    {
        public DeletePessoaFisicaValidator()
        {
            RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage("Cpf is required");
        }
    }
}
