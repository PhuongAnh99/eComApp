using Contracts.Persistence;
using MediatR;
using Product.Domain.Repositories;
using Product.Domain.Entities;

namespace Product.Application.Commands
{
    public record CreateProductCommand(string Name, string Description, decimal Price, string ImageUrl, Guid CategoryId) : IRequest<Guid>;
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _repo;
        private readonly IBaseUnitOfWork _uow;

        public CreateProductHandler(IProductRepository repo, IBaseUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Guid> Handle(CreateProductCommand cmd, CancellationToken ct)
        {
            var product = new Domain.Entities.Product
            {
                Name = cmd.Name,
                Description = cmd.Description,
                Price = cmd.Price,
                ImageUrl = cmd.ImageUrl,
                CategoryId = cmd.CategoryId
            };

            await _repo.AddAsync(product);
            await _uow.SaveChangesAsync(ct);
            return product.Id;
        }
    }
}
