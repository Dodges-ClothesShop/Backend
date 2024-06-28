using Dodges.ClothesShop.Common.Domain.Enums;

namespace Dodges.ClothesShop.Common.Domain.ValueObjects;

public sealed class ProductId(string value) : Id<ProductId>(value), IIdDescription
{
    public static string RussianEntityTypeName => "Товар";
    public static string Prefix => FormatPrefix(BoundedContext.Selling, entityType: "prdct");
}

