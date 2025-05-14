using Infrastructure.Persistence;
using Product.Domain.Entities;
using Product.Domain.Repositories;

namespace Product.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category, ProductDbContext>, ICategoryRepository
    {
        public CategoryRepository(ProductDbContext context) : base(context) { }
    }
}
