using Dodges.ClothesShop.Common.Domain.Annotations;
using Dodges.ClothesShop.Common.Domain.ValueObjects;

namespace Dodges.ClothesShop.Domain.Product;

public sealed class Product : IHaveId<ProductId>
{
    public Product(ProductId id)
    {
        Id = id;
    }

    public ProductId Id { get; }

}

