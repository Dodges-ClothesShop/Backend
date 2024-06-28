using System.Diagnostics.CodeAnalysis;
using Dodges.ClothesShop.Common.Domain.Enums;
using Dodges.ClothesShop.Common.Utils;

namespace Dodges.ClothesShop.Common.Domain.ValueObjects;

public abstract class Id<TId>(string value) : IId<TId>
    where TId : Id<TId>, IIdDescription
{
    public static TId New() => Parse(IdGenerator.NewId(TId.Prefix), provider: null);

    public string Value { get; } = value;

    public override string ToString() => Value;

    protected static string FormatPrefix(BoundedContext boundedContext, string entityType) =>
        $"{BoundedContextMapper.GetPrefix(boundedContext)}-{entityType}-";

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

    public static bool TryParse(string? text, [NotNullWhen(true)] out TId? id) => TryParse(text, provider: null, out id);

    public static TId Parse(string? text) => Parse(text, provider: null);

    public static TId Parse(string? text, IFormatProvider? provider) => TryParse(text, provider: null, out var id)
        ? id
        : throw new FormatException($"Неверный формат идентификатора для сущности «{TId.RussianEntityTypeName}»: {text}");


    public static bool TryParse([NotNullWhen(true)] string? text, IFormatProvider? provider, [MaybeNullWhen(false)] out TId result)
    {
        text = text?.Trim();

        if (string.IsNullOrWhiteSpace(text) || text.StartsWith(TId.Prefix) is false)
        {
            result = default;
            return false;
        }

        result = ExpressionActivator.Create<string, TId>(text);
        return true;
    }
}

public interface IId<TId>: IParsable<TId>, IEquatable<TId> where TId: IId<TId>
{
    static abstract bool TryParse(string? text, [NotNullWhen(true)] out TId? id);

    static abstract TId Parse(string? text);

    string Value { get; }
}

public interface IIdDescription
{
    static abstract string RussianEntityTypeName { get; }

    static abstract string Prefix { get; }
}
