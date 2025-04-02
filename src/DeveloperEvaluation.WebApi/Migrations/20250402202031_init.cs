using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperEvaluation.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PessoaFisica",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "varchar(15)", nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    Rua = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Bairro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "char(2)", nullable: false),
                    DataNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(15)", nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFisica", x => x.Cpf);
                });

            migrationBuilder.CreateTable(
                name: "PessoaJuridica",
                columns: table => new
                {
                    Cnpj = table.Column<string>(type: "varchar(14)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Isento = table.Column<bool>(type: "boolean", nullable: false),
                    Cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    Rua = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Bairro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "char(2)", nullable: false),
                    DataNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(15)", nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaJuridica", x => x.Cnpj);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PessoaJuridica_Email",
                table: "PessoaJuridica",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PessoaFisica");

            migrationBuilder.DropTable(
                name: "PessoaJuridica");
        }
    }
}
