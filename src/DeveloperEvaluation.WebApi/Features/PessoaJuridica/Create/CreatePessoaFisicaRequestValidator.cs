using System.Text.RegularExpressions;
using FluentValidation;

namespace DeveloperEvaluation.WebApi.Features.PessoaJuridica.Create;

public class CreatePessoaJuridicaRequestValidator : AbstractValidator<CreatePessoaJuridicaRequest>
{
    public CreatePessoaJuridicaRequestValidator()
    {
        RuleFor(p => p.InscricaoEstadual)
            .Must(IsValid)
            .WithMessage($"InscricaoEstadual é inválido! Formato oficial");
        RuleFor(p => p.RazaoSocial).NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(p => p.Cep).NotEmpty()
            .WithMessage("Campo obrigatorio")
            .MaximumLength(8)
            .WithMessage("Tamanho max 8");
            
        RuleFor(p => p.Rua).NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(p => p.Numero).NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(p => p.Bairro).NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(p => p.Cidade).NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(p => p.Estado).NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(x => x.DataNascimento)
            .Must(ValidarDataNascimento)
            .WithMessage("Data de nascimento invalida ou menor maior que 120 anos");
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Email inv�lido."); 
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

    public bool IsValid(string? cnpj)
    {
        // Remove caracteres não numéricos
        cnpj = Regex.Replace(cnpj, "[^0-9]", "");

        // Verifica se possui 14 dígitos
        if (cnpj.Length != 14)
            return false;

        // Verifica se todos os dígitos são iguais (sequências como 00.000.000/0000-00)
        // o que é um caso inválido, embora passe na verificação matemática
        if (cnpj.Distinct().Count() == 1)
            return false;

        // Calcula o primeiro dígito verificador
        int[] multiplier1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int sum = 0;

        for (int i = 0; i < 12; i++)
            sum += int.Parse(cnpj[i].ToString()) * multiplier1[i];

        int remainder = sum % 11;
        int digit1 = remainder < 2 ? 0 : 11 - remainder;

        // Verifica o primeiro dígito verificador
        if (int.Parse(cnpj[12].ToString()) != digit1)
            return false;

        // Calcula o segundo dígito verificador
        int[] multiplier2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        sum = 0;

        for (int i = 0; i < 13; i++)
            sum += int.Parse(cnpj[i].ToString()) * multiplier2[i];

        remainder = sum % 11;
        int digit2 = remainder < 2 ? 0 : 11 - remainder;

        // Verifica o segundo dígito verificador
        if (int.Parse(cnpj[13].ToString()) != digit2)
            return false;

        return true;
    }


}