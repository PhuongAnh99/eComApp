using Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public abstract class BaseUnitOfWork<TContext> : IBaseUnitOfWork where TContext : DbContext
    {
        protected readonly TContext _context;

        protected BaseUnitOfWork(TContext context)
        {
            _context = context;
        }

        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => _context.SaveChangesAsync(cancellationToken);
    }
}
