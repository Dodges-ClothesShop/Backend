using System.Diagnostics.CodeAnalysis;

namespace Dodges.ClothesShop.Common.Domain.ValueObjects;

public abstract class Id<TId> : IId<TId> where TId : Id<TId>
{
    private protected Id(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public override string ToString() => Value;

    protected static bool TryParse(string? text, string prefix, Func<string, TId> idFactory, [NotNullWhen(true)] out TId? id)
    {
        text = text?.Trim();
        if (string.IsNullOrWhiteSpace(text) || text.StartsWith(prefix) is false)
        {
            id = default;
            return false;
        }

        id = idFactory(text);
        return true;
    }


    protected static string FormatPrefix(string boundedContextName, string entityType) =>
        $"{boundedContextName}-{entityType}-";

    #region Equatable Members

    public bool Equals(TId? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Value == other.Value;
    }

    public override bool Equals(object? obj) => Equals(obj as TId);

    public override int GetHashCode() => Value.GetHashCode();

    public static bool operator ==(Id<TId>? left, Id<TId>? right) => Equals(left, right);

    public static bool operator !=(Id<TId>? left, Id<TId>? right) => !Equals(left, right);

    #endregion Equatable Members

    public static bool TryParse(string? text, [NotNullWhen(true)] out TId? id) => throw new NotImplementedException();

    public static TId Parse(string? text) => throw new NotImplementedException();
}

public interface IId<TId>: IId, IParsable<TId>, IEquatable<TId> where TId: IId<TId>
{
    static abstract bool TryParse(string? text, [NotNullWhen(true)] out TId? id);

    static abstract TId Parse(string? text);
}

public interface IId
{
    string Value { get; }
}
