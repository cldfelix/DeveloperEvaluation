using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperEvaluation.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class alter_pessoa_juridica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PessoaJuridica",
                table: "PessoaJuridica");

            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "PessoaJuridica");

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual",
                table: "PessoaJuridica",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "PessoaJuridica",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PessoaJuridica",
                table: "PessoaJuridica",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PessoaJuridica",
                table: "PessoaJuridica");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PessoaJuridica");

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual",
                table: "PessoaJuridica",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "PessoaJuridica",
                type: "varchar(14)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PessoaJuridica",
                table: "PessoaJuridica",
                column: "Cnpj");
        }
    }
}
