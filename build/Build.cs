using Nuke.Common;

namespace Dodges.ClothesShop.Build;

class Build : NukeBuild
{
    public static int Main () => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    private readonly Configuration Co = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    Target Clean => target => target
        .Before(Restore)
        .Executes(() =>
        {
        });

    Target Restore => target => target
        .Executes(() =>
        {
        });

    Target Compile => target => target
        .DependsOn(Restore)
        .Executes(() =>
        {
        });
}
