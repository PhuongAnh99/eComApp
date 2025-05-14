using Contracts.Persistence;
using MediatR;
using Product.Domain.Entities;
using Product.Domain.Repositories;

namespace Product.Application.Commands
{
    public record CreateCategoryCommand(string Name, string? Description) : IRequest<Guid>;
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _repo;
        private readonly IBaseUnitOfWork _uow;

        public CreateCategoryHandler(ICategoryRepository repo, IBaseUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Guid> Handle(CreateCategoryCommand cmd, CancellationToken ct)
        {
            var category = new Category
            {
                Name = cmd.Name,
                Description = cmd.Description
            };

            await _repo.AddAsync(category);
            await _uow.SaveChangesAsync(ct);
            return category.Id;
        }
    }

}
