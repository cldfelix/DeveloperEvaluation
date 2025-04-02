using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperEvaluation.Application.PessoaJuridica.Create;
using DeveloperEvaluation.Application.PessoaJuridica.Delete;
using FluentValidation;

namespace DeveloperEvaluation.Application.PessoaJuridica.Get
{
    public class DeletePessoaJuridicaValidator : AbstractValidator<DeletePessoaJuridicaCommand>
    {
        public DeletePessoaJuridicaValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Cpf is required");
        }
    }
}
