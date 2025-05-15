using MediatR;
using Product.Application.Dtos;
using Product.Domain.Repositories;

namespace Product.Application.Queries
{
    public record GetCategoryByIdQuery(Guid Id) : IRequest<CategoryDto>;
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto?>
    {
        private readonly ICategoryRepository _repo;

        public GetCategoryByIdHandler(ICategoryRepository repo) => _repo = repo;

        public async Task<CategoryDto?> Handle(GetCategoryByIdQuery query, CancellationToken ct)
        {
            var category = await _repo.GetByIdAsync(query.Id);
            return category is null ? null : new CategoryDto(category.Id, category.Name, category.Description);
        }
    }
}
