using AutoMapper;
using DeveloperEvaluation.Application.PessoaJuridica.Create;
using DeveloperEvaluation.Application.PessoaJuridica.Delete;
using DeveloperEvaluation.Application.PessoaJuridica.Get;
using DeveloperEvaluation.Application.PessoaJuridica.GetAll;
using DeveloperEvaluation.Application.PessoaJuridica.Update;
using DeveloperEvaluation.WebApi.Common;
using DeveloperEvaluation.WebApi.Features.PessoaJuridica.Create;
using DeveloperEvaluation.WebApi.Features.PessoaJuridica.Delete;
using DeveloperEvaluation.WebApi.Features.PessoaJuridica.Get;
using DeveloperEvaluation.WebApi.Features.PessoaJuridica.GetAll;
using DeveloperEvaluation.WebApi.Features.PessoaJuridica.Update;
using DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperEvaluation.WebApi.Features.PessoaJuridica;

[ApiController]
[Route("api/[controller]")]
public class PessoaJuridicaController: BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public PessoaJuridicaController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreatePessoaJuridicaResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreatePessoaJuridica([FromBody] CreatePessoaJuridicaRequest request,
        CancellationToken cancellationToken)
    {
        var validator = new CreatePessoaJuridicaRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreatePessoaJuridicaCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreatePessoaJuridicaResponse>
        {
            Success = true,
            Message = "Pessoa juridica created successfully",
            Data = _mapper.Map<CreatePessoaJuridicaResponse>(response)
        });
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdatePessoaJuridicaResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdatePessoaJuridicaRequest request,
        CancellationToken cancellationToken)
    {
        var validator = new UpdatePessoaJuridicaRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        if(!id.ToString().Equals(request.Id.ToString()))
            return BadRequest("Objeto invalido");

        var command = _mapper.Map<UpdatePessoaJuridicaCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(_mapper.Map<UpdatePessoaJuridicaResponse>(response));
   
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseWithData<GetListPessoaJuridicaResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllPessoasFisicas(CancellationToken cancellationToken)
    {
        var command = new GetListPessoaJuridicaComand();
        var response = await _mediator.Send(command, cancellationToken);
        return !response.ListPessoaJuridicaResults.Any() ? NotFound() : Ok(_mapper.Map<GetListPessoaJuridicaResponse>(response));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<DeletePessoaJuridicaResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPessoaJuridica([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetPessoaJuridicaRequest(id){ };
        var validator = new GetPessoaJuridicaRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetPessoaJuridicaCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return response == null ? NotFound() : Ok(_mapper.Map<GetPessoaJuridicaResponse>(response));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletePessoaJuridica([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeletePessoaJuridicaRequest(id) { };
        var validator = new DeletePessoaJuridicaRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeletePessoaJuridicaCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return !response ? NotFound() : Ok(response);
    }
}