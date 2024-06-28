using System.Diagnostics.CodeAnalysis;
using Dodges.ClothesShop.Common.Domain.Constants;
using Dodges.ClothesShop.Common.Utils;

namespace Dodges.ClothesShop.Common.Domain.ValueObjects;

public sealed class ProductId(string value) : Id<ProductId>(value), IId<ProductId>
{
    public static string Prefix => FormatPrefix(BoundContext.Selling, "prdct");

    public static bool TryParse(string? text, [NotNullWhen(true)] out ProductId? id) =>
        TryParse(text, Prefix, value => new ProductId(value), out id);

    public static ProductId Parse(string? text) =>
        TryParse(text, out var id) ? id : throw new FormatException($"Неверный формат идентификатора: {text}");

}
