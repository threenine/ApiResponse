#tool dotnet:?package=GitVersion.Tool&version=5.12.0

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
string version = String.Empty;
//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() => {
    DotNetClean("./");
});

Task("Restore")
    .IsDependentOn("Clean")
    .Description("Restoring the solution dependencies")
    .Does(() => {
           var projects = GetFiles("./**/*.csproj");

              foreach(var project in projects )
              {
                  Information($"Building { project.ToString()}");
                  DotNetRestore(project.ToString());
              } 
});

Task("Version")
    .Does(() => {
   var result = GitVersion(new GitVersionSettings {
        UpdateAssemblyInfo = true
    });
    
    version = result.NuGetVersionV2;
    Information($"Version: { version }");
});

Task("Build")
    .IsDependentOn("Version")
    .Does(() => {
     var buildSettings = new DotNetBuildSettings {
                        Configuration = configuration,
                        MSBuildSettings = new DotNetMSBuildSettings()
                                                      .WithProperty("Version", version)
                                                      .WithProperty("AssemblyVersion", version)
                                                      .WithProperty("FileVersion", version)
                       };
     var projects = GetFiles("./**/*.csproj");
     foreach(var project in projects )
     {
         Information($"Building {project.ToString()}");
         DotNetBuild(project.ToString(),buildSettings);
     }
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() => {

       var testSettings = new DotNetTestSettings  {
                                  Configuration = configuration,
                                  NoBuild = true,
                              };
     var projects = GetFiles("./tests/*/*.csproj");
     foreach(var project in projects )
     {
       Information($"Running Tests : { project.ToString()}");
       DotNetTest(project.ToString(), testSettings );
     }
});

Task("Pack")
 .IsDependentOn("Test")
 .Does(() => {
 
   var settings = new DotNetPackSettings
    {
        Configuration = configuration,
        OutputDirectory = "./.artifacts",
        NoBuild = true,
        NoRestore = true,
        MSBuildSettings = new DotNetMSBuildSettings()
                        .WithProperty("PackageVersion", version)
                        .WithProperty("Copyright", $"© Copyright threenine.co.uk {DateTime.Now.Year}")
                        .WithProperty("Version", version)
    };
    
    DotNetPack("./ApiResponse.sln", settings);
 });
 
Task("PublishNuget")
 .IsDependentOn("Pack")
 .Does(context => {
   if (BuildSystem.GitHubActions.IsRunningOnGitHubActions)
   {
     foreach(var file in GetFiles("./.artifacts/*.nupkg"))
     {
       Information("Publishing {0}...", file.GetFilename().FullPath);
       DotNetNuGetPush(file, new DotNetNuGetPushSettings {
          ApiKey = context.EnvironmentVariable("NUGET_API_KEY"),
          Source = "https://api.nuget.org/v3/index.json"
       });
     }
   }
 }); 
 
 Task("PublishGithub")
  .IsDependentOn("Pack")
  .Does(context => {
  if (BuildSystem.GitHubActions.IsRunningOnGitHubActions)
   {
      foreach(var file in GetFiles("./.artifacts/*.nupkg"))
      {
        Information("Publishing {0}...", file.GetFilename().FullPath);
        DotNetNuGetPush(file, new DotNetNuGetPushSettings {
              ApiKey = EnvironmentVariable("GITHUB_TOKEN"),
              Source = "https://nuget.pkg.github.com/threenine/index.json"
        });
      } 
   } 
 }); 



//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

Task("Default")
       .IsDependentOn("Clean")
       .IsDependentOn("Restore")
       .IsDependentOn("Version")
       .IsDependentOn("Build")
       .IsDependentOn("Test")
       .IsDependentOn("Pack")
       .IsDependentOn("PublishNuget")
       .IsDependentOn("PublishGithub");

RunTarget(target);