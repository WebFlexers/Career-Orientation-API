using System.Diagnostics;

using CareerOrientation.Application.Common.Abstractions.Persistence;

using Microsoft.EntityFrameworkCore.Storage;

namespace CareerOrientation.Infrastructure.Persistence.Repositories;

public class RepositoryBase : IRepositoryBase
{
    protected readonly ApplicationDbContext _dbContext;
    private IDbContextTransaction? _transaction;
    
    public bool IsTransactionRunning => _transaction is not null;

    public RepositoryBase(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task BeginTransactionAsync(CancellationToken token = default)
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync(token);
    }

    public async Task CommitTransactionAsync(CancellationToken token = default)
    {
        Debug.Assert(_transaction is not null);
        
        try
        {
            await _dbContext.SaveChangesAsync(token);
            await _transaction.CommitAsync(token);
        }
        catch
        {
            await RollbackTransactionAsync();
            throw;
        }
        finally
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }
    }

    public async Task RollbackTransactionAsync()
    {
        Debug.Assert(_transaction is not null);
        
        try
        {
            await _transaction.RollbackAsync();
        }
        finally
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }
    }
}