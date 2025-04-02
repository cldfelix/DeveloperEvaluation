using AutoMapper;
using DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace DeveloperEvaluation.Application.PessoaFisica.GetAll;

public class GetListPessoaFisicaHandler : IRequestHandler<GetListPessoaFisicaComand, GetListPessoaFisicaResult>
{
    private readonly IPessoaFisicaRepository _repository;
    private readonly IMapper _mapper;

    public GetListPessoaFisicaHandler(IPessoaFisicaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;

    }

    public async Task<GetListPessoaFisicaResult> Handle(GetListPessoaFisicaComand request, CancellationToken cancellationToken)
    {
        var pessoas = await _repository.GetAllAsync(cancellationToken);
        var mapped = _mapper.Map<GetListPessoaFisicaResult>(pessoas);


        /*
         *	
           Error: response status is 500
           
           Response body
           Download
           AutoMapper.AutoMapperMappingException: Cannot create interface System.Collections.Generic.IEnumerable`1[DeveloperEvaluation.Application.PessoaFisica.Get.GetPessoaFisicaResult]
         */

        return mapped;
    }
}