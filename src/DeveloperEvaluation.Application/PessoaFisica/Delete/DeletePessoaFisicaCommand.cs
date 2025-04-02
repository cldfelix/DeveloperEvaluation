using DeveloperEvaluation.Application.PessoaFisica.Get;
using MediatR;

namespace DeveloperEvaluation.Application.PessoaFisica.Delete;

public class DeletePessoaFisicaCommand : IRequest<bool>
{
    public DeletePessoaFisicaCommand(string cpf)
    {
        Cpf = cpf;

    }
    public string Cpf { get; private set; }
}