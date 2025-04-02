using System.Text.RegularExpressions;
using FluentValidation;

namespace DeveloperEvaluation.Application.PessoaJuridica.Create
{
    public class CreatePessoaJuridicaCommandValidator: AbstractValidator<CreatePessoaJuridicaCommand>
    {
        public CreatePessoaJuridicaCommandValidator()
        {
            RuleFor(p => p.InscricaoEstadual)
                .Must(IsValid)
                .WithMessage("CNPJ inválido");

            // se isento for true, inscrição estadual deve ser nula
            RuleFor(p => p.InscricaoEstadual)
                .Null()
                .When(p => p.Isento)
                .WithMessage("Inscrição estadual deve ser nula se isento for true");
            // se isento for false, inscrição estadual não deve ser nula
            
            RuleFor(p => p.InscricaoEstadual)
                .NotNull()
                .When(p => !p.Isento)
                .WithMessage("Inscrição estadual não pode ser nula se isento for false");

            RuleFor(p => p.RazaoSocial).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Cep).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Rua).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Numero).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Bairro).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Cidade).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Estado).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.DataNascimento).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Telefone).NotEmpty().WithMessage("Campo obrigatorio");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Campo obrigatorio");


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

        public static string Format(string cnpj)
        {
            // Remove caracteres não numéricos
            cnpj = Regex.Replace(cnpj, "[^0-9]", "");

            if (cnpj.Length != 14)
                return string.Empty;

            return $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/" +
                   $"{cnpj.Substring(8, 4)}-{cnpj.Substring(12, 2)}";
        }
    }
}