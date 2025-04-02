using AutoMapper;
using DeveloperEvaluation.Application.PessoaJuridica.Update;
using DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace DeveloperEvaluation.Application.PessoaJuridica.Create;

public class CreatePessoaJuridicaHandler : IRequestHandler<CreatePessoaJuridicaCommand, CreatePessoaJuridicaResult>
{
    private readonly IPessoaJuridicaRepository _repository;
    private readonly IMapper _mapper;

    public CreatePessoaJuridicaHandler(IPessoaJuridicaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;

    }

    public async Task<CreatePessoaJuridicaResult> Handle(CreatePessoaJuridicaCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreatePessoaJuridicaCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var emailExiste = await _repository.GetByEmailAsync(command.Email, cancellationToken);
        if (emailExiste)
        {
            throw new ValidationException("Email ja registrado!");
        }

        if (command.InscricaoEstadual is not null)
        {
            var pessoa = await _repository.GetByInscricaoAsync(command.InscricaoEstadual, cancellationToken);
            if (pessoa)
            {
                throw new ValidationException("Inscricao Estadual ja registrada!");
            }
        }


        var product = _mapper.Map<global::DeveloperEvaluation.Domain.Entities.PessoaJuridica>(command);
        var createdProduct = await _repository.CreateAsync(product, cancellationToken);
        var result = _mapper.Map<CreatePessoaJuridicaResult>(createdProduct);
        return result;

      
    }
}