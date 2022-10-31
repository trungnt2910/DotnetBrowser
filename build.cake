#load cake\TargetEnvironment.cake
#addin "Cake.FileHelpers&version=5.0.0"
#addin "Cake.Incubator&version=7.0.0"

// VARS
var version = Argument("build-version", "0.1.0");
var packageVersion = Argument("package-version", "0.1.0");
var configuration = Argument("configuration", "Release");
var target = Argument("target", "Default");

var msbuildsettings = new DotNetMSBuildSettings();
var supportedVersionBands = new List<string>() {"7.0.100-rc.2", "7.0.100"};

const string manifestName = "Trungnt2910.NET.Sdk.Browser";
var manifestPack = $"{manifestName}.Manifest-{TargetEnvironment.DotNetCliFeatureBand}.{packageVersion}.nupkg";
var manifestPackPath = $"out/nuget/{manifestPack}";

var packNames = new List<string>()
{
    "Trungnt2910.Browser.Ref",
    "Trungnt2910.Browser.Runtime",
    "Trungnt2910.Browser.Sdk"
};

var coreLibraryNames = new List<string>()
{
    "Trungnt2910.Browser"
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
    msbuildsettings = msbuildsettings.WithProperty("Authors", "Trung Nguyen");
    msbuildsettings = msbuildsettings.WithProperty("_BrowserVersion", version);
});

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    foreach (var name in coreLibraryNames)
    {
        DotNetRestore($"src/{name}/{name}.csproj");
    }

    foreach (var name in packNames)
    {
        DotNetRestore($"workload/{name}/{name}.csproj");
    }

    DotNetRestore("workload/Trungnt2910.NET.Sdk.Browser/Trungnt2910.NET.Sdk.Browser.csproj");
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

Task("BuildCoreLibraries")
    .IsDependentOn("Restore")
    .Does(() =>
{
    var settings = new DotNetBuildSettings
    {
        Configuration = configuration,
        MSBuildSettings = msbuildsettings,
        NoRestore = true
    };

    foreach (var name in coreLibraryNames)
    {
        DotNetBuild($"src/{name}/{name}.csproj", settings);
    }
});

Task("BuildAndPackageWorkload")
    .IsDependentOn("BuildCoreLibraries")
    .Does(() =>
{
    var buildSettings = new DotNetBuildSettings
    {
        MSBuildSettings = msbuildsettings,
        Configuration = configuration,
        NoRestore = true,
        // Don't build the core libraries
        NoDependencies = true,
        // Always re-generate files.
        NoIncremental = true
    };

    var packSettings = new DotNetPackSettings
    {
        MSBuildSettings = msbuildsettings,
        Configuration = configuration,
        OutputDirectory = "out/nuget",
        NoRestore = true,
        NoBuild = true,
        NoDependencies = true
    };

    foreach (var name in packNames)
    {
        DotNetBuild($"workload/{name}/{name}.csproj", buildSettings);
        DotNetPack($"workload/{name}/{name}.csproj", packSettings);
    }

    foreach (var band in supportedVersionBands)
    {
        buildSettings.MSBuildSettings = buildSettings.MSBuildSettings.WithProperty("_BrowserManifestVersionBand", band);
        DotNetBuild("workload/Trungnt2910.NET.Sdk.Browser/Trungnt2910.NET.Sdk.Browser.csproj", buildSettings);

        packSettings.MSBuildSettings = packSettings.MSBuildSettings.WithProperty("_BrowserManifestVersionBand", band);
        DotNetPack("workload/Trungnt2910.NET.Sdk.Browser/Trungnt2910.NET.Sdk.Browser.csproj", packSettings);
    }
});

Task("InstallWorkload")
    .IsDependentOn("BuildAndPackageWorkload")
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

Task("BuildAndPackageTestFramework")
    .IsDependentOn("Init")
    .Does(() =>
{
    var packSettings = new DotNetPackSettings
    {
        MSBuildSettings = msbuildsettings,
        Configuration = configuration,
        OutputDirectory = "out/nuget",
    };

    DotNetPack($"tests/Trungnt2910.Browser.ObservationFramework/Trungnt2910.Browser.ObservationFramework/Trungnt2910.Browser.ObservationFramework.csproj", packSettings);
});

Task("RunWorkloadTests")
    .IsDependentOn("BuildAndPackageTestFramework")
    .Does(() =>
{
    var testSettings = new DotNetTestSettings
    {
        Configuration = configuration,
    };

    DotNetTest("tests/Trungnt2910.Browser.Tests/Trungnt2910.Browser.Tests.csproj", testSettings);
});

Task("BuildAndPackageAdditionalNuGetPackages")
    .IsDependentOn("Init")
    .Does(() =>
{
    var packSettings = new DotNetPackSettings
    {
        MSBuildSettings = msbuildsettings,
        Configuration = configuration,
        OutputDirectory = "out/nuget",
    };

    DotNetPack("sample/Rickroller/Rickroller.csproj", packSettings);
});

// TASK TARGETS

Task("Default")
    .IsDependentOn("BuildAndPackageWorkload");

// EXECUTION

RunTarget(target);
