namespace Dodges.ClothesShop.Common.Domain.Annotations;

public interface IHaveId<out TId>
{
    public TId Id { get; }
}
