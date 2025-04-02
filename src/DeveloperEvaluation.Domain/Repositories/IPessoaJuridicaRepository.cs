using Domain.Entities;

namespace DeveloperEvaluation.Domain.Repositories;

public interface IPessoaJuridicaRepository
{
    Task<PessoaJuridica> CreateAsync(PessoaJuridica pessoaJuridica, CancellationToken cancellationToken = default);
    Task<PessoaJuridica> UpdateAsync(string cnpj, PessoaJuridica pessoaJuridica, CancellationToken cancellationToken = default);
    Task<PessoaJuridica?> GetByIdAsync(string cnpj, CancellationToken cancellationToken = default);
    Task<IEnumerable<PessoaJuridica>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(string cnpj, CancellationToken cancellationToken = default);
}