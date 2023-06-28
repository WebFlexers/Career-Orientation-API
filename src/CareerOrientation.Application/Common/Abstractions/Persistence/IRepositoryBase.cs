namespace CareerOrientation.Application.Common.Abstractions.Persistence;

public interface IRepositoryBase
{
    Task BeginTransactionAsync(CancellationToken token = default);
    Task CommitTransactionAsync(CancellationToken token = default);
    Task RollbackTransactionAsync();
}