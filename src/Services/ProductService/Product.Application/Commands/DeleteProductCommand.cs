using Contracts.Persistence;
using MediatR;
using Product.Domain.Repositories;

namespace Product.Application.Commands
{
    public record DeleteProductCommand(Guid Id) : IRequest<bool>;
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _repo;
        private readonly IBaseUnitOfWork _uow;

        public DeleteProductHandler(IProductRepository repo, IBaseUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<bool> Handle(DeleteProductCommand cmd, CancellationToken ct)
        {
            var product = await _repo.GetByIdAsync(cmd.Id);
            if (product == null) return false;

            _repo.Delete(product);
            await _uow.SaveChangesAsync(ct);
            return true;
        }
    }
}
