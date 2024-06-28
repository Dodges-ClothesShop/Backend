using NetArchTest.Rules;
using static Dodges.ClothesShop.Domain.DomainAssemblyReference;

namespace Dodges.ClothesShop.Solution.UnitTests.Domain;

public sealed class TypeDefinitionTests
{
    [Fact(DisplayName = "Все типы в сборке должны быть sealed")]
    public void DomainTypes_Should_BeSealed()
    {
        var result = Types.InAssembly(Assembly).Should().BeSealed().GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}
