using Contracts.Persistence;
using MediatR;
using Product.Domain.Repositories;

namespace Product.Application.Commands
{
    public record UpdateCategoryCommand(Guid Id, string Name, string? Description) : IRequest<bool>;

    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICategoryRepository _repo;
        private readonly IBaseUnitOfWork _uow;

        public UpdateCategoryHandler(ICategoryRepository repo, IBaseUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<bool> Handle(UpdateCategoryCommand cmd, CancellationToken ct)
        {
            var category = await _repo.GetByIdAsync(cmd.Id);
            if (category == null) return false;

            category.Name = cmd.Name;
            category.Description = cmd.Description;

            _repo.Update(category);
            await _uow.SaveChangesAsync(ct);
            return true;
        }
    }

}
