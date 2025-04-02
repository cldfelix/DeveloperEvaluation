using Domain.Entities;

namespace DeveloperEvaluation.Domain.Repositories;

public interface IPessoaFisicaRepository
{
    Task<PessoaFisica> CreateAsync(PessoaFisica pessoaFisica, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(string cpf, PessoaFisica pessoaFisica, CancellationToken cancellationToken = default);
    Task<PessoaFisica?> GetByIdAsync(string cpf, CancellationToken cancellationToken = default);
    Task<IEnumerable<PessoaFisica>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(string cpf, CancellationToken cancellationToken = default);
}