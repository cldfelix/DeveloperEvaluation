using DeveloperEvaluation.Domain.Entities;
using DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeveloperEvaluation.ORM.Repositories;

public class PessoaJuridicaRepository : IPessoaJuridicaRepository
{
    private readonly DefaultContext _context;

    public PessoaJuridicaRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<PessoaJuridica> CreateAsync(PessoaJuridica pessoaJuridica, CancellationToken cancellationToken = default)
    {
        await _context.PessoaJuridicas.AddAsync(pessoaJuridica, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return pessoaJuridica;

    }
    public async Task<bool> UpdateAsync(Guid id, PessoaJuridica pessoaJuridica, CancellationToken cancellationToken = default)
    {
        var p = await _context.PessoaJuridicas.FindAsync(id, cancellationToken);
        if (p is null)
        {
            throw new Exception("Pessoa não encontrada");
        }

        _context.PessoaJuridicas.Update(pessoaJuridica);
        await _context.SaveChangesAsync(cancellationToken);
        return true;

    }
    public async Task<PessoaJuridica?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
       return await _context.PessoaJuridicas.FindAsync(id, cancellationToken);
    }
    public async Task<IEnumerable<PessoaJuridica>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.PessoaJuridicas.ToListAsync(cancellationToken);
    }
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var p = await _context.PessoaJuridicas.FindAsync(id, cancellationToken);
        if (p is null)
        {
            return false;
        }
        _context.PessoaJuridicas.Remove(p);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.PessoaJuridicas.AnyAsync(x => x.Email == email, cancellationToken);
    }

    public async Task<bool> GetByInscricaoAsync(string inscricao, CancellationToken cancellationToken)
    {
        return await _context.PessoaJuridicas.AnyAsync(x => x.InscricaoEstadual == inscricao, cancellationToken);
    }
}