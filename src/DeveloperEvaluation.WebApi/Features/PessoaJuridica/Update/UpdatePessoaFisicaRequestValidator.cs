using System.Text.RegularExpressions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace DeveloperEvaluation.WebApi.Features.PessoaJuridica.Update;

public class UpdatePessoaJuridicaRequestValidator : AbstractValidator<UpdatePessoaJuridicaRequest>
{
    public UpdatePessoaJuridicaRequestValidator()
    {
        RuleFor(p => p.Id)
           .NotEmpty()
           .WithMessage("Campo obrigatorio");
        RuleFor(p => p.InscricaoEstadual)
            .MaximumLength(20).WithMessage("Max 20 caracteres")
            .NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(p => p.Cep).NotEmpty().WithMessage("Campo cep obrigatorio");
        RuleFor(p => p.Rua).NotEmpty().WithMessage("Campo rua obrigatorio");
        RuleFor(p => p.Numero).NotEmpty().WithMessage("Campo numero obrigatorio");
        RuleFor(p => p.Bairro).NotEmpty().WithMessage("Campo bairro obrigatorio");
        RuleFor(p => p.Cidade).NotEmpty().WithMessage("Campo cidade obrigatorio");
        RuleFor(p => p.Estado).NotEmpty().WithMessage("Campo estado obrigatorio");
        // deve ser obrigatorio false ou true
        RuleFor(p => p.Isento)
            .Must(x => x == true || x == false)
            .WithMessage("Campo Isento obrigatorio");

        RuleFor(x => x.DataNascimento)
            .Must(ValidarDataNascimento)
            .WithMessage("Data de nascimento inv�lida ou menor que 18 anos");
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Email invalido.");
        RuleFor(x => x.Telefone)
            .Matches(@"^\+?[1-9]\d{1,14}$")
            .WithMessage("Telefone inv�lido.");

    }

    private bool ValidarDataNascimento(DateOnly dataNascimento)
    {
        var idade = DateTime.Today.Year - dataNascimento.Year;
        if (dataNascimento > DateOnly.FromDateTime(DateTime.Today.AddYears(-idade))) idade--;
        return idade >= 0 && idade <= 120;
    }

}