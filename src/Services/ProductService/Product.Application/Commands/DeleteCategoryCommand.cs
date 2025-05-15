using Contracts.Persistence;
using MediatR;
using Product.Domain.Repositories;

namespace Product.Application.Commands
{
    public record DeleteCategoryCommand(Guid Id) : IRequest<bool>;

    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository _repo;
        private readonly IBaseUnitOfWork _uow;

        public DeleteCategoryHandler(ICategoryRepository repo, IBaseUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<bool> Handle(DeleteCategoryCommand cmd, CancellationToken ct)
        {
            var category = await _repo.GetByIdAsync(cmd.Id);
            if (category == null) return false;

            _repo.Delete(category);
            await _uow.SaveChangesAsync(ct);
            return true;
        }
    }

}
