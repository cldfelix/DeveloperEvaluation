using System.Text.RegularExpressions;
using FluentValidation;

namespace DeveloperEvaluation.WebApi.Features.PessoaFisica.Create;

public class CreatePessoaFisicaRequestValidator : AbstractValidator<CreatePessoaFisicaRequest>
{
    public CreatePessoaFisicaRequestValidator()
    {
        RuleFor(p => p.Cpf)
            .Must(IsCpfValid)
            .WithMessage("Cpf Invalido");
        RuleFor(p => p.Nome).NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(p => p.Cep).NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(p => p.Rua).NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(p => p.Numero).NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(p => p.Bairro).NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(p => p.Cidade).NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(p => p.Estado).NotEmpty().WithMessage("Campo obrigatorio");
        RuleFor(x => x.DataNascimento)
            .Must(ValidarDataNascimento)
            .WithMessage("Data de nascimento inv�lida ou menor que 18 anos");
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
        return idade >= 0 && idade >= 18; 
    }

    public bool IsCpfValid(string cpf)
    {
        // Remove caracteres n�o num�ricos
        cpf = Regex.Replace(cpf, "[^0-9]", "");

        // Verifica se possui 11 d�gitos
        if (cpf.Length != 11)
            return false;

        // Verifica se todos os d�gitos s�o iguais (sequ�ncias como 111.111.111-11)
        // o que � um caso inv�lido, embora passe na verifica��o matem�tica
        if (cpf.Distinct().Count() == 1)
            return false;

        // Calcula o primeiro d�gito verificador
        int sum = 0;
        for (int i = 0; i < 9; i++)
            sum += int.Parse(cpf[i].ToString()) * (10 - i);

        int remainder = sum % 11;
        int digit1 = remainder < 2 ? 0 : 11 - remainder;

        // Verifica o primeiro d�gito verificador
        if (int.Parse(cpf[9].ToString()) != digit1)
            return false;

        // Calcula o segundo d�gito verificador
        sum = 0;
        for (int i = 0; i < 10; i++)
            sum += int.Parse(cpf[i].ToString()) * (11 - i);

        remainder = sum % 11;
        int digit2 = remainder < 2 ? 0 : 11 - remainder;

        // Verifica o segundo d�gito verificador
        if (int.Parse(cpf[10].ToString()) != digit2)
            return false;

        return true;
    }
}