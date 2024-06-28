using Dodges.ClothesShop.Common.Domain.Enums;

namespace Dodges.ClothesShop.Common.Utils;

internal static class BoundedContextMapper
{
    public static string GetPrefix(BoundedContext boundedContext) => boundedContext switch
    {
        BoundedContext.Selling => "sell",
        BoundedContext.Identity => "ident",
        BoundedContext.Administration => "admin",
        _ => throw new ArgumentOutOfRangeException(nameof(boundedContext), boundedContext, message: null)
    };
}
