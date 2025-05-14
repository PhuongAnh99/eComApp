using Contracts.Entities;

namespace Product.Domain.Entities
{
    public class Category : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
