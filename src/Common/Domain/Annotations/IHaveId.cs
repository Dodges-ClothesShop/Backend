namespace Dodges.ClothesShop.Common.Domain.Annotations;

public interface IHaveId<out TId> : IDomainEntity
{
    public TId Id { get; }
}
