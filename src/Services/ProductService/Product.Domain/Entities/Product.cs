using Contracts.Entities;

namespace Product.Domain.Entities
{
    public class Product : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = default!;
        public Guid CategoryId { get; set; }

        public Category Category { get; set; } = default!;
    }
}
