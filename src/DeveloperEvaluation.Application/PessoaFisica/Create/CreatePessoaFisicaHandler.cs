using AutoMapper;
using DeveloperEvaluation.Application.PessoaFisica.Update;
using DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace DeveloperEvaluation.Application.PessoaFisica.Create;

public class CreatePessoaFisicaHandler : IRequestHandler<CreatePessoaFisicaCommand, CreatePessoaFisicaResult>
{
    private readonly IPessoaFisicaRepository _repository;
    private readonly IMapper _mapper;

    public CreatePessoaFisicaHandler(IPessoaFisicaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;

    }

    public async Task<CreatePessoaFisicaResult> Handle(CreatePessoaFisicaCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreatePessoaFisicaCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var pessoa = await _repository.GetByIdAsync(command.Cpf, cancellationToken);
        if(pessoa != null)
        {
            throw new ValidationException("Cpf ja registrado!");
        }


        var product = _mapper.Map<global::DeveloperEvaluation.Domain.Entities.PessoaFisica>(command);
        var createdProduct = await _repository.CreateAsync(product, cancellationToken);
        var result = _mapper.Map<CreatePessoaFisicaResult>(createdProduct);
        return result;

      
    }
}