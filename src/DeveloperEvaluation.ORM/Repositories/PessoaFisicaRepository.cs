using System.Linq.Expressions;
using DeveloperEvaluation.Domain.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Pipelines.Sockets.Unofficial.Arenas;

namespace DeveloperEvaluation.ORM.Repositories;

public class PessoaFisicaRepository : IPessoaFisicaRepository
{
    private readonly DefaultContext _context;

    public PessoaFisicaRepository(DefaultContext context)
    {
        _context = context;
    }
    public async Task<PessoaFisica> CreateAsync(PessoaFisica pessoaFisica, CancellationToken cancellationToken = default)
    {
        await _context.PessoaFisicas.AddAsync(pessoaFisica, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return pessoaFisica;

    }
    public async Task<bool> UpdateAsync(string cpf, PessoaFisica pessoaFisica, CancellationToken cancellationToken = default)
    {
       var pessoa = await _context.PessoaFisicas.FindAsync(cpf, cancellationToken);
       if (pessoa is null) return false;
       
       pessoa.Nome = pessoaFisica.Nome;

       await _context.SaveChangesAsync(cancellationToken);

       return true;

    }
    public async Task<PessoaFisica?> GetByIdAsync(string cpf, CancellationToken cancellationToken = default)
    {
        return await _context.PessoaFisicas.FindAsync(cpf, cancellationToken);
    }
    public async Task<IEnumerable<PessoaFisica>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.PessoaFisicas.ToListAsync(cancellationToken);
    }
    public async Task<bool> DeleteAsync(string cpf, CancellationToken cancellationToken = default)
    {
        var pessoa = await _context.PessoaFisicas.FindAsync(cpf, cancellationToken);
        
        if (pessoa is null) return false;
        
        
        _context.PessoaFisicas.Remove(pessoa);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}