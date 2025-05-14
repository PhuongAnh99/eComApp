using Contracts.Persistence;
using Product.Domain.Entities;

namespace Product.Domain.Repositories
{
    public interface IProductRepository : IBaseRepository<Entities.Product>
    {
    }
}
