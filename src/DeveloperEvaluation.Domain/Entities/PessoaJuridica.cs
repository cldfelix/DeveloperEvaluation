﻿using System.ComponentModel.DataAnnotations;

namespace DeveloperEvaluation.Domain.Entities
{
    public class PessoaJuridica
    {
        [Key]
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string? InscricaoEstadual { get; set; } 
        public bool Isento { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

    }

}
