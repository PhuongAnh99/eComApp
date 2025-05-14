using MediatR;
using Product.Application.Dtos;
using Product.Domain.Repositories;

namespace Product.Application.Queries
{
    public record GetAllCategoriesQuery : IRequest<List<CategoryDto>>;
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
    {
        private readonly ICategoryRepository _repo;

        public GetAllCategoriesHandler(ICategoryRepository repo) => _repo = repo;

        public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery query, CancellationToken ct)
        {
            var categories = await _repo.GetAllAsync();
            return categories.Select(c => new CategoryDto(c.Id, c.Name, c.Description)).ToList();
        }
    }

}
