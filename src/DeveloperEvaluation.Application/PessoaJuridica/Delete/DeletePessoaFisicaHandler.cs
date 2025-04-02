using AutoMapper;
using DeveloperEvaluation.Application.PessoaJuridica.Get;
using DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace DeveloperEvaluation.Application.PessoaJuridica.Delete;

public class DeletePessoaJuridicaHandler : IRequestHandler<DeletePessoaJuridicaCommand, bool>
{
    private readonly IPessoaJuridicaRepository _repository;
    private readonly IMapper _mapper;

    public DeletePessoaJuridicaHandler(IPessoaJuridicaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;

    }

    public async Task<bool> Handle(DeletePessoaJuridicaCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeletePessoaJuridicaValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var pessoa  = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (pessoa == null)
        {
            return false;
        }
        await _repository.DeleteAsync(pessoa.Id, cancellationToken);

        return true;

    }
}