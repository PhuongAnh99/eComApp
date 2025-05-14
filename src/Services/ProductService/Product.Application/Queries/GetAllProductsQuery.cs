using MediatR;
using Product.Application.Dtos;
using Product.Domain.Repositories;

namespace Product.Application.Queries
{
    public record GetAllProductsQuery : IRequest<List<ProductDto>>;

    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _repo;

        public GetAllProductsHandler(IProductRepository repo) => _repo = repo;

        public async Task<List<ProductDto>> Handle(GetAllProductsQuery query, CancellationToken ct)
        {
            var products = await _repo.GetAllAsync();
            return products.Select(p => new ProductDto(p.Id, p.Name, p.Description, p.Price, p.ImageUrl, p.CategoryId)).ToList();
        }
    }
}
