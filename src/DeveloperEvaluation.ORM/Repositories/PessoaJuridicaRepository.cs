using DeveloperEvaluation.Domain.Repositories;
using Domain.Entities;

namespace DeveloperEvaluation.ORM.Repositories;

public class PessoaJuridicaRepository : IPessoaJuridicaRepository
{
    public Task<PessoaJuridica> CreateAsync(PessoaJuridica pessoaJuridica, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public Task<PessoaJuridica> UpdateAsync(string cnpj, PessoaJuridica pessoaJuridica, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public Task<PessoaJuridica?> GetByIdAsync(string cnpj, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public Task<IEnumerable<PessoaJuridica>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public Task<bool> DeleteAsync(string cnpj, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}