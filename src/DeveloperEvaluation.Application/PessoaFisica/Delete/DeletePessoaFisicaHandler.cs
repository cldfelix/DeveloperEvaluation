using AutoMapper;
using DeveloperEvaluation.Application.PessoaFisica.Get;
using DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace DeveloperEvaluation.Application.PessoaFisica.Delete;

public class DeletePessoaFisicaHandler : IRequestHandler<DeletePessoaFisicaCommand, bool>
{
    private readonly IPessoaFisicaRepository _repository;
    private readonly IMapper _mapper;

    public DeletePessoaFisicaHandler(IPessoaFisicaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;

    }

    public async Task<bool> Handle(DeletePessoaFisicaCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeletePessoaFisicaValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var pessoa  = await _repository.GetByIdAsync(request.Cpf, cancellationToken);
        if (pessoa == null)
        {
            return false;
        }
        await _repository.DeleteAsync(pessoa.Cpf, cancellationToken);

        return true;

    }
}