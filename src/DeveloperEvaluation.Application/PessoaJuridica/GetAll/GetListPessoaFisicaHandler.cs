using AutoMapper;
using DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace DeveloperEvaluation.Application.PessoaJuridica.GetAll;

public class GetListPessoaJuridicaHandler : IRequestHandler<GetListPessoaJuridicaComand, GetListPessoaJuridicaResult>
{
    private readonly IPessoaJuridicaRepository _repository;
    private readonly IMapper _mapper;

    public GetListPessoaJuridicaHandler(IPessoaJuridicaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;

    }

    public async Task<GetListPessoaJuridicaResult> Handle(GetListPessoaJuridicaComand request, CancellationToken cancellationToken)
    {
        var pessoas = await _repository.GetAllAsync(cancellationToken);
        var mapped = _mapper.Map<GetListPessoaJuridicaResult>(pessoas);


        /*
         *	
           Error: response status is 500
           
           Response body
           Download
           AutoMapper.AutoMapperMappingException: Cannot create interface System.Collections.Generic.IEnumerable`1[DeveloperEvaluation.Application.PessoaJuridica.Get.GetPessoaJuridicaResult]
         */

        return mapped;
    }
}