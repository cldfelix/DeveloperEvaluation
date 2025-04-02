using AutoMapper;
using DeveloperEvaluation.Application.PessoaFisica.Create;
using DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace DeveloperEvaluation.Application.PessoaFisica.Update;

public class UpdatePessoaFisicaHandler : IRequestHandler<UpdatePessoaFisicaCommand, UpdatePessoaFisicaResult>
{
    private readonly IPessoaFisicaRepository _repository;
    private readonly IMapper _mapper;

    public UpdatePessoaFisicaHandler(IPessoaFisicaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;

    }

    public async Task<UpdatePessoaFisicaResult> Handle(UpdatePessoaFisicaCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdatePessoaFisicaCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var pessoa = await _repository.GetByIdAsync(command.Cpf, cancellationToken);
        if (pessoa == null)
        {
            throw new ValidationException("Pessoa não encontrada");
        }
        await _repository.UpdateAsync(pessoa.Cpf, pessoa, cancellationToken);

        var result = _mapper.Map<UpdatePessoaFisicaResult>(pessoa);
        return result;

      
    }
}