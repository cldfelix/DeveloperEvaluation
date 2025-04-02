using DeveloperEvaluation.Domain.Entities;

namespace DeveloperEvaluation.Domain.Repositories;

public interface IPessoaJuridicaRepository
{
    Task<PessoaJuridica> CreateAsync(PessoaJuridica pessoaJuridica, CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(Guid id, PessoaJuridica pessoaJuridica,
        CancellationToken cancellationToken = default);

    Task<PessoaJuridica?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<PessoaJuridica>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<bool> GetByInscricaoAsync(string inscricao, CancellationToken cancellationToken);
}
