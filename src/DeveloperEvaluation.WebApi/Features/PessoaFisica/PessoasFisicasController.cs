using AutoMapper;
using DeveloperEvaluation.Application.PessoaFisica.Create;
using DeveloperEvaluation.Application.PessoaFisica.Delete;
using DeveloperEvaluation.Application.PessoaFisica.Get;
using DeveloperEvaluation.Application.PessoaFisica.GetAll;
using DeveloperEvaluation.Application.PessoaFisica.Update;
using DeveloperEvaluation.WebApi.Common;
using DeveloperEvaluation.WebApi.Features.PessoaFisica.Create;
using DeveloperEvaluation.WebApi.Features.PessoaFisica.Delete;
using DeveloperEvaluation.WebApi.Features.PessoaFisica.Get;
using DeveloperEvaluation.WebApi.Features.PessoaFisica.GetAll;
using DeveloperEvaluation.WebApi.Features.PessoaFisica.Update;
using DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperEvaluation.WebApi.Features.PessoaFisica;

[ApiController]
[Route("api/[controller]")]
public class PessoaFisicaController: BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public PessoaFisicaController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreatePessoaFisicaResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreatePessoaFisica([FromBody] CreatePessoaFisicaRequest request,
        CancellationToken cancellationToken)
    {
        var validator = new CreatePessoaFisicaRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreatePessoaFisicaCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreatePessoaFisicaResponse>
        {
            Success = true,
            Message = "Pessoa fisica created successfully",
            Data = _mapper.Map<CreatePessoaFisicaResponse>(response)
        });
    }

    [HttpPut("{cpf}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdatePessoaFisicaResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateProduct([FromRoute] string cpf, [FromBody] UpdatePessoaFisicaRequest request,
        CancellationToken cancellationToken)
    {
        var validator = new UpdatePessoaFisicaRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        if(!cpf.ToLower().Equals(request.Cpf.ToLower()))
            return BadRequest("Cpf não pode ser alterado");

        var command = _mapper.Map<UpdatePessoaFisicaCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(_mapper.Map<UpdatePessoaFisicaResponse>(response));
   
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseWithData<GetListPessoaFisicaResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllPessoasFisicas(CancellationToken cancellationToken)
    {
        var command = new GetListPessoaFisicaComand();
        var response = await _mediator.Send(command, cancellationToken);
        return !response.ListPessoaFisicaResults.Any() ? NotFound() : Ok(_mapper.Map<GetListPessoaFisicaResponse>(response));
    }

    [HttpGet("{cpf}")]
    [ProducesResponseType(typeof(ApiResponseWithData<DeletePessoaFisicaResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPessoaFisica([FromRoute] string cpf, CancellationToken cancellationToken)
    {
        var request = new GetPessoaFisicaRequest(cpf){ };
        var validator = new GetPessoaFisicaRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetPessoaFisicaCommand>(request.Cpf);
        var response = await _mediator.Send(command, cancellationToken);

        return response == null ? NotFound() : Ok(_mapper.Map<GetPessoaFisicaResponse>(response));
    }

    [HttpDelete("{cpf}")]
    [ProducesResponseType(typeof(ApiResponseWithData<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletePessoaFisica([FromRoute] string cpf, CancellationToken cancellationToken)
    {
        var request = new DeletePessoaFisicaRequest(cpf) { };
        var validator = new DeletePessoaFisicaRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeletePessoaFisicaCommand>(request.Cpf);
        var response = await _mediator.Send(command, cancellationToken);

        return !response ? NotFound() : Ok(response);
    }
}