using FluentValidation;

namespace DeveloperEvaluation.Application.PessoaFisica.Create
{
    public class CreatePessoaFisicaCommandValidator: AbstractValidator<CreatePessoaFisicaCommand>
    {
        public CreatePessoaFisicaCommandValidator()
        {
            RuleFor(p => p.Cpf).Length(11).WithMessage("Camppo obrigatorio no formato xxxxxxxxxxx com 11 caracteres");
            RuleFor(p => p.Nome).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Cep).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Rua).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Numero).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Bairro).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Cidade).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Estado).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.DataNascimento).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Telefone).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Campo obrigatorio");

            RuleFor(p => p.Cpf).Length(11).WithMessage("Camppo obrigatorio no formato xxxxxxxxxxx com 11 caracteres");
            RuleFor(p => p.Nome).NotEmpty().WithMessage("Campo obrigatorio");

        }
    }
}