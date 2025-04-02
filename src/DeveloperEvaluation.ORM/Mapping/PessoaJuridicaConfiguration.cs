using DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeveloperEvaluation.ORM.Mapping;

public class PessoaJuridicaConfiguration : IEntityTypeConfiguration<PessoaJuridica>
{
    public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
    {
        builder.ToTable("PessoaJuridica");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.RazaoSocial).IsRequired().HasMaxLength(100);
        builder.Property(p => p.InscricaoEstadual).HasMaxLength(20);
        builder.Property(p => p.Isento).IsRequired();
        builder.Property(p => p.Cep).IsRequired().HasColumnType("varchar(8)");
        builder.Property(p => p.Rua).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Numero).IsRequired().HasMaxLength(10);
        builder.Property(p => p.Bairro).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Cidade).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Estado).IsRequired().HasColumnType("char(2)");
        builder.Property(p => p.Telefone).IsRequired().HasColumnType("varchar(15)");
        builder.Property(p => p.Email).IsRequired().HasMaxLength(100);
        builder.HasIndex(p => p.Email)
            .IsUnique();


    }
}