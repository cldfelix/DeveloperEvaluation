using AutoMapper;
using DeveloperEvaluation.Application.PessoaFisica.GetAll;
using DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace DeveloperEvaluation.Application.PessoaFisica.Get;

public class GetPessoaFisicaHandler : IRequestHandler<GetPessoaFisicaCommand, GetPessoaFisicaResult?>
{
    private readonly IPessoaFisicaRepository _repository;
    private readonly IMapper _mapper;

    public GetPessoaFisicaHandler(IPessoaFisicaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;

    }

    public async Task<GetPessoaFisicaResult?> Handle(GetPessoaFisicaCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetPessoaFisicaValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var pessoa  = await _repository.GetByIdAsync(request.Cpf, cancellationToken);
        return _mapper.Map<GetPessoaFisicaResult>(pessoa);

    }
}