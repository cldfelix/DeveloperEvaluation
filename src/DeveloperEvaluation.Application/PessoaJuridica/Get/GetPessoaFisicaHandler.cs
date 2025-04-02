using AutoMapper;
using DeveloperEvaluation.Application.PessoaJuridica.GetAll;
using DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace DeveloperEvaluation.Application.PessoaJuridica.Get;

public class GetPessoaJuridicaHandler : IRequestHandler<GetPessoaJuridicaCommand, GetPessoaJuridicaResult?>
{
    private readonly IPessoaJuridicaRepository _repository;
    private readonly IMapper _mapper;

    public GetPessoaJuridicaHandler(IPessoaJuridicaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;

    }

    public async Task<GetPessoaJuridicaResult?> Handle(GetPessoaJuridicaCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetPessoaJuridicaValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var pessoa  = await _repository.GetByIdAsync(request.Id, cancellationToken);
        return _mapper.Map<GetPessoaJuridicaResult>(pessoa);

    }
}