using Infrastructure.Persistence;

namespace Product.Infrastructure.Repositories
{
    public class UnitOfWork : BaseUnitOfWork<ProductDbContext>
    {
        public UnitOfWork(ProductDbContext context) : base(context) { }
    }
}
