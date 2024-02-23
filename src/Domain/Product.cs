using Dodges.ClothesShop.Common.Domain.Annotations;
using Dodges.ClothesShop.Common.Domain.ValueObjects;

namespace Dodges.ClothesShop.Domain;

public sealed class Product : IHaveId<ProductId>
{
    private Product(ProductId id)
    {
        Id = id;
    }

    public ProductId Id { get; }

}

