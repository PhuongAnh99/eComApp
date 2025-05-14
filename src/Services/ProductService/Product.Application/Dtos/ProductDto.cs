namespace Product.Application.Dtos
{
    public record ProductDto(Guid Id, string Name, string Description, decimal Price, string ImageUrl, Guid CategoryId);
}
