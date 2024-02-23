namespace Dodges.ClothesShop.Domain.Common.Utils;

public static class IdGenerator
{
    private const char PrefixSeparator = '-';

    public static string NewId(string prefix)
    {
        if (!prefix.EndsWith(PrefixSeparator))
        {
            prefix += PrefixSeparator;
        }

        var uniq = NewId();
        return prefix + uniq;
    }

    private static string NewId()
    {
        var uniq = Guid.NewGuid();
        var encoded = Base64UrlEncode(uniq);;
        return encoded;
    }

    private static string Base64UrlEncode(Guid uniq) =>
        Convert.ToBase64String(uniq.ToByteArray())
            .Replace('+', '-')
            .Replace('/', '_')
            .Replace("=", "");
}
