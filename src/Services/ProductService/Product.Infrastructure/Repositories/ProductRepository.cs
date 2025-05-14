using Infrastructure.Persistence;
using Product.Domain.Repositories;

namespace Product.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Domain.Entities.Product, ProductDbContext>, IProductRepository
    {
        public ProductRepository(ProductDbContext context) : base(context) { }
    }
}
