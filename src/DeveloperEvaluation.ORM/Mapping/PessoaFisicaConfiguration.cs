using DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeveloperEvaluation.ORM.Mapping;

public class PessoaFisicaConfiguration: IEntityTypeConfiguration<PessoaFisica>
{
    public void Configure(EntityTypeBuilder<PessoaFisica> builder)
    {
        builder.ToTable("PessoaFisica");
        builder.HasKey(p => p.Cpf);
        builder.Property(p => p.Cpf).IsRequired().HasColumnType("varchar(15)");
        builder.Property(p=> p.Nome).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Email).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Cep).IsRequired().HasColumnType("varchar(8)");
        builder.Property(p => p.Rua).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Numero).IsRequired().HasMaxLength(10);
        builder.Property(p => p.Bairro).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Cidade).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Estado).IsRequired().HasColumnType("char(2)");
        builder.Property(p => p.DataNascimento).IsRequired().HasColumnType("date");
        builder.Property(p => p.Telefone).IsRequired().HasColumnType("varchar(15)");



    }
        
}