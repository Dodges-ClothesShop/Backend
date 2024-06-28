using Microsoft.Extensions.DependencyInjection;

namespace Dodges.ClothesShop.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) =>
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(ApplicationAssemblyReference.Assembly));
}
