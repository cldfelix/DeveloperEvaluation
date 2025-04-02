using System.Text.RegularExpressions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace DeveloperEvaluation.WebApi.Features.PessoaFisica.Update;

public class UpdatePessoaFisicaRequestValidator : AbstractValidator<UpdatePessoaFisicaRequest>
{
    public UpdatePessoaFisicaRequestValidator()
    {
        RuleFor(p => p.Cpf)
           .NotEmpty()
           .WithMessage("Cpf obrigatorio");
        RuleFor(p => p.Nome).NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(p => p.Cep).NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(p => p.Rua).NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(p => p.Numero).NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(p => p.Bairro).NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(p => p.Cidade).NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(p => p.Estado).NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(x => x.DataNascimento)
            .Must(ValidarDataNascimento)
            .WithMessage("Data de nascimento inválida ou menor que 18 anos");
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Email inválido.");
        RuleFor(x => x.Telefone)
            .Matches(@"^\+?[1-9]\d{1,14}$")
            .WithMessage("Telefone inválido.");

    }

    private bool CepfIguais(string cpf, string cpfComparacao)
    {
        return cpf.ToLower().Equals(cpfComparacao.ToLower());
    }

    private bool ValidarDataNascimento(DateOnly dataNascimento)
    {
        var idade = DateTime.Today.Year - dataNascimento.Year;
        if (dataNascimento > DateOnly.FromDateTime(DateTime.Today.AddYears(-idade))) idade--;
        return idade >= 0 && idade >= 18;
    }

}