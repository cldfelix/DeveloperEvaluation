using AutoMapper;
using DeveloperEvaluation.Application.PessoaJuridica.Create;
using DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace DeveloperEvaluation.Application.PessoaJuridica.Update;

public class UpdatePessoaJuridicaHandler : IRequestHandler<UpdatePessoaJuridicaCommand, UpdatePessoaJuridicaResult>
{
    private readonly IPessoaJuridicaRepository _repository;
    private readonly IMapper _mapper;

    public UpdatePessoaJuridicaHandler(IPessoaJuridicaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;

    }

    public async Task<UpdatePessoaJuridicaResult> Handle(UpdatePessoaJuridicaCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdatePessoaJuridicaCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var pessoa = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (pessoa == null)
        {
            throw new ValidationException("Pessoa nao encontrada");
        }
        await _repository.UpdateAsync(pessoa.Id, pessoa, cancellationToken);

        var result = _mapper.Map<UpdatePessoaJuridicaResult>(pessoa);
        return result;

      
    }
}