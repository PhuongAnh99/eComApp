using MediatR;
using Product.Application.Dtos;
using Product.Domain.Repositories;

namespace Product.Application.Queries
{
    public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto>;
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly IProductRepository _repo;

        public GetProductByIdHandler(IProductRepository repo) => _repo = repo;

        public async Task<ProductDto?> Handle(GetProductByIdQuery query, CancellationToken ct)
        {
            var product = await _repo.GetByIdAsync(query.Id);
            return product is null ? null
                : new ProductDto(product.Id, product.Name, product.Description, product.Price, product.ImageUrl, product.CategoryId);
        }
    }
}
