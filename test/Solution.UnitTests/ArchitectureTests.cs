using Dodges.ClothesShop.Application;
using Dodges.ClothesShop.Domain;
using Dodges.ClothesShop.Infrastructure;
using NetArchTest.Rules;

namespace Dodges.ClothesShop.Solution.UnitTests;

public sealed class ArchitectureTests
{
    private const string RootNamespace = "Dodges.ClothesShop.";

    private const string Application = $"{RootNamespace}{nameof(Application)}";
    private const string Domain = $"{RootNamespace}{nameof(Domain)}";
    private const string Host = $"{RootNamespace}{nameof(Host)}";
    private const string Infrastructure = $"{RootNamespace}{nameof(Infrastructure)}";
    private const string Web = $"{RootNamespace}{nameof(Web)}";

    [Fact(DisplayName = "Сборка Domain не должна ссылаться на другие сборки")]
    public void Domain_Should_NotHaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = DomainAssemblyReference.Assembly;
        var otherProjects = new[] { Application, Infrastructure, Web, Host };
        // Act
        var result = Types.InAssembly(assembly).Should().NotHaveDependencyOnAll(otherProjects).GetResult();
        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact(DisplayName = "Сборка Application может ссылаться только на Domain")]
    public void Application_Should_HaveDependencyOnlyOnDomain()
    {
        // Arrange
        var assembly = ApplicationAssemblyReference.Assembly;
        var otherProjects = new[] { Infrastructure, Web, Host };
        // Act
        var result = Types.InAssembly(assembly).Should().NotHaveDependencyOnAll(otherProjects).GetResult();
        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact(DisplayName = "Сборка Infrastructure может ссылаться только на Application")]
    public void Infrastructure_Should_HaveDependencyOnlyOnApplication()
    {
        // Arrange
        var assembly = InfrastructureAssemblyReference.Assembly;
        var otherProjects = new[] { Domain, Web, Host };
        // Act
        var result = Types.InAssembly(assembly).Should().NotHaveDependencyOnAll(otherProjects).GetResult();
        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact(DisplayName = "Сборка Web может ссылаться только на Application")]
    public void Web_Should_HaveDependencyOnlyOnApplication()
    {
        // Arrange
        var assembly = InfrastructureAssemblyReference.Assembly;
        var otherProjects = new[] { Infrastructure, Web, Host };
        // Act
        var result = Types.InAssembly(assembly).Should().NotHaveDependencyOnAll(otherProjects).GetResult();
        // Assert
        result.IsSuccessful.Should().BeTrue();
    }
}
