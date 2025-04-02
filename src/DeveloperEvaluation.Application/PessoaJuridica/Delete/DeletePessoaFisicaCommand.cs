using DeveloperEvaluation.Application.PessoaJuridica.Get;
using MediatR;

namespace DeveloperEvaluation.Application.PessoaJuridica.Delete;

public class DeletePessoaJuridicaCommand : IRequest<bool>
{
    public DeletePessoaJuridicaCommand(Guid id)
    {
        Id = id;

    }
    public Guid Id { get; private set; }
}