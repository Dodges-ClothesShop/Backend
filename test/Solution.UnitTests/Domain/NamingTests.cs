using Dodges.ClothesShop.Common.Domain.Annotations;
using Dodges.ClothesShop.Domain;
using NetArchTest.Rules;

namespace Dodges.ClothesShop.Solution.UnitTests.Domain;

public sealed class NamingTests
{
    private const string DomainEventPostfix = "DomainEvent";

    [Fact(DisplayName = $"Типы доменных событий должны иметь заказчиваться на {DomainEventPostfix}")]
    public void DomainEvents_Should_HaveDomainEventPostfix()
    {
        var result = Types.InAssembly(DomainAssemblyReference.Assembly)
            .That()
            .ImplementInterface(typeof(IDomainEvent))
            .Should()
            .HaveNameEndingWith(DomainEventPostfix)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}
