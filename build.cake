#load cake\TargetEnvironment.cake
#addin "Cake.FileHelpers&version=5.0.0"
#addin "Cake.Incubator&version=7.0.0"

// VARS
var version = Argument("build-version", "0.1.0");
var packageVersion = Argument("package-version", "0.1.0");
var configuration = Argument("configuration", "Release");
var target = Argument("target", "Default");

var msbuildsettings = new DotNetMSBuildSettings();
var supportedVersionBands = new List<string>() {"6.0.100", "6.0.200", "6.0.300", "6.0.400"};

const string manifestName = "Trungnt2910.NET.Sdk.Browser";
var manifestPack = $"{manifestName}.Manifest-{TargetEnvironment.DotNetCliFeatureBand}.{packageVersion}.nupkg";
var manifestPackPath = $"out/nuget/{manifestPack}";

var packNames = new List<string>()
{
    "Trungnt2910.Browser.Ref",
    "Trungnt2910.Browser.Runtime",
    "Trungnt2910.Browser.Sdk"
};

// TASKS

Task("Init")
    .Does(() =>
{
    Console.WriteLine("Version: " + version);
    Console.WriteLine("Package Version: " + packageVersion);

    // Assign some common properties
    msbuildsettings = msbuildsettings.WithProperty("Version", version);
    msbuildsettings = msbuildsettings.WithProperty("PackageVersion", packageVersion);
    msbuildsettings = msbuildsettings.WithProperty("Authors", "'Trung Nguyen'");
    msbuildsettings = msbuildsettings.WithProperty("PackageLicenseUrl", "'https://github.com/trungnt2910/DotnetBrowser/blob/master/LICENSE'");
    msbuildsettings = msbuildsettings.WithProperty("_BrowserVersion", version);
});

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    foreach (var name in packNames)
    {
        DotNetRestore($"workload/{name}/{name}.csproj");
    }

});

Task("Clean")
    .IsDependentOn("Init")
    .Does(() =>
{

});

Task("FullClean")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DeleteDirectory("out", new DeleteDirectorySettings {
        Recursive = true,
        Force = true
    });
});

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
{
    var settings = new DotNetBuildSettings
    {
        Configuration = configuration,
        MSBuildSettings = msbuildsettings
    };

    DotNetBuild("src/Trungnt2910.Browser/Trungnt2910.Browser.csproj", settings);
});

Task("PackageWorkload")
    .IsDependentOn("Build")
    .Does(() =>
{
    var packSettings = new DotNetPackSettings
    {
        MSBuildSettings = msbuildsettings,
        Configuration = configuration,
        OutputDirectory = "out/nuget",
        // Some of the nugets here depend on output generated during build.
        NoBuild = false
    };

    foreach (var name in packNames)
    {
        DotNetPack($"workload/{name}/{name}.csproj", packSettings);
    }

    foreach (var band in supportedVersionBands)
    {
        packSettings.MSBuildSettings = packSettings.MSBuildSettings.WithProperty("_BrowserManifestVersionBand", band);
        DotNetPack("workload/Trungnt2910.NET.Sdk.Browser/Trungnt2910.NET.Sdk.Browser.csproj", packSettings);
    }
});

Task("InstallWorkload")
    .IsDependentOn("PackageWorkload")
    .Does(() =>
{
    Console.WriteLine($"Installing workload for SDK version {TargetEnvironment.DotNetCliFeatureBand}, at {TargetEnvironment.DotNetInstallPath}");
    Console.WriteLine($"Installing manifests to {TargetEnvironment.DotNetManifestPath}");
    TargetEnvironment.InstallManifests(manifestName, manifestPackPath);
    Console.WriteLine($"Installing packs to {TargetEnvironment.DotNetPacksPath}");
    foreach (var name in packNames)
    {
        Console.WriteLine($"Installing {name}");
        var pack = $"{name}.{packageVersion}.nupkg";
        var packPath = $"out/nuget/{pack}";
        TargetEnvironment.InstallPack(name, packageVersion, packPath);
    }
    Console.WriteLine($"Registering \"browser\" installed workload...");
    TargetEnvironment.RegisterInstalledWorkload("browser");
});

Task("UninstallWorkload")
    .Does(() =>
{
    Console.WriteLine($"Uninstalling workload for SDK version {TargetEnvironment.DotNetCliFeatureBand}, at {TargetEnvironment.DotNetInstallPath}");
    Console.WriteLine($"Removing manifests from {TargetEnvironment.DotNetManifestPath}");
    TargetEnvironment.UninstallManifests(manifestName);
    Console.WriteLine($"Removing packs from {TargetEnvironment.DotNetPacksPath}");
    foreach (var name in packNames)
    {
        Console.WriteLine($"Removing {name}");
        TargetEnvironment.UninstallPack(name, version);
    }
    Console.WriteLine($"Unregistering \"browser\" installed workload...");
    TargetEnvironment.UnregisterInstalledWorkload("browser");
});

// TASK TARGETS

Task("Default")
    .IsDependentOn("Build")
    .IsDependentOn("PackageWorkload");

// EXECUTION

RunTarget(target);
