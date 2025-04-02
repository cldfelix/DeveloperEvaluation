using DeveloperEvaluation.Application.PessoaJuridica.Create;
using FluentValidation;

namespace DeveloperEvaluation.Application.PessoaJuridica.Update
{
    public class UpdatePessoaJuridicaCommandValidator: AbstractValidator<UpdatePessoaJuridicaCommand>
    {
        public UpdatePessoaJuridicaCommandValidator()
        {
            RuleFor(p => p.InscricaoEstadual)
                .MaximumLength(20).WithMessage("Camppo obrigatorio no formato xxxxxxxxxxx com 20 caracteres");
            RuleFor(p => p.RazaoSocial).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Cep).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Rua).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Numero).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Estado).NotEmpty().WithMessage("Campo estado obrigatorio");
            // deve ser obrigatorio false ou true
            RuleFor(p => p.Isento)
                .Must(x => x == true || x == false)
                .WithMessage("Campo Isento obrigatorio");

            RuleFor(p => p.Bairro).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Cidade).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.DataNascimento).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Telefone).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Campo obrigatorio");


        }
    }
}