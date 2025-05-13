namespace Contracts.Persistence
{
    public interface IBaseUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
