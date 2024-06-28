namespace Dodges.ClothesShop.Common.Utils;

public static class IdGenerator
{
    private const char PrefixSeparator = '-';

    public static string NewId(string prefix)
    {
        if (prefix.EndsWith(PrefixSeparator) is false)
        {
            prefix += PrefixSeparator;
        }

        var uniq = NewId();
        return prefix + uniq;
    }

    private static string NewId()
    {
        var id = Guid.NewGuid();
        var encoded = Base64UrlEncode(id);;
        return encoded;
    }

    private static string Base64UrlEncode(Guid id) =>
        Convert.ToBase64String(id.ToByteArray())
            .Replace('+', '-')
            .Replace('/', '_')
            .Replace("=", "");
}
