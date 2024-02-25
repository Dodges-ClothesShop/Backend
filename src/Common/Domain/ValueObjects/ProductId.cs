using System.Diagnostics.CodeAnalysis;
using Dodges.ClothesShop.Common.Domain.Constants;
using Dodges.ClothesShop.Common.Utils;

namespace Dodges.ClothesShop.Common.Domain.ValueObjects;

public sealed class ProductId : Id<ProductId>, IId<ProductId>
{
    private ProductId(string value) : base(value)
    {
    }

    public static string Prefix => FormatPrefix(BoundContext.Selling, "prod");

    public static bool TryParse(string? text, [NotNullWhen(true)] out ProductId? id) =>
        TryParse(text, Prefix, value => new ProductId(value), out id);

    public static ProductId Parse(string? text) =>
        TryParse(text, out var id) ? id : throw new FormatException($"Неверный формат идентификатора: {text}");

    public static ProductId New() => Parse(IdGenerator.NewId(Prefix));
}
