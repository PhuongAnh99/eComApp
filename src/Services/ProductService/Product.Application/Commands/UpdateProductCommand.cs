using Contracts.Persistence;
using MediatR;
using Product.Domain.Repositories;

namespace Product.Application.Commands
{
    public record UpdateProductCommand(Guid Id, string Name, string Description, decimal Price, string ImageUrl, Guid CategoryId) : IRequest<bool>;
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _repo;
        private readonly IBaseUnitOfWork _uow;

        public UpdateProductHandler(IProductRepository repo, IBaseUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<bool> Handle(UpdateProductCommand cmd, CancellationToken ct)
        {
            var product = await _repo.GetByIdAsync(cmd.Id);
            if (product == null) return false;

            product.Name = cmd.Name;
            product.Description = cmd.Description;
            product.Price = cmd.Price;
            product.ImageUrl = cmd.ImageUrl;
            product.CategoryId = cmd.CategoryId;

            _repo.Update(product);
            await _uow.SaveChangesAsync(ct);
            return true;
        }
    }
}
