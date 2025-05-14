using Contracts.Persistence;
using Product.Domain.Entities;

namespace Product.Domain.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
    }
}
