#tool dotnet:?package=GitVersion.Tool&version=6.0.2

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var nuget_api_key = Argument("nuget_api_key", "");
var github_token = Argument("github_token", "");

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


Task("Build")
    .IsDependentOn("Restore")
    .Does(() => {
       
       var version = GitVersion(new GitVersionSettings {
           Branch = "main"
        });
       
     var buildSettings = new DotNetBuildSettings {
                        Configuration = configuration,
                        MSBuildSettings = new DotNetMSBuildSettings()
                                                      .WithProperty("Version", version.FullSemVer)
                                                      .WithProperty("AssemblyVersion", version.AssemblySemVer)
                                                      .WithProperty("FileVersion", version.FullSemVer)
                       };
     var projects = GetFiles("./src/**/*.csproj");
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
 
  var version = GitVersion(new GitVersionSettings {
            Branch = "main"
         });
         
       
   var settings = new DotNetPackSettings
    {
        Configuration = configuration,
        OutputDirectory = "./.artifacts",
        NoBuild = true,
        NoRestore = true,
        MSBuildSettings = new DotNetMSBuildSettings()
                        .WithProperty("PackageVersion", version.MajorMinorPatch)
                        .WithProperty("Copyright", $"© Copyright threenine.co.uk {DateTime.Now.Year}")
                        .WithProperty("Version", version.AssemblySemVer)
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
          ApiKey = nuget_api_key,
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
              ApiKey = github_token,
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
       .IsDependentOn("Build")
       .IsDependentOn("Test")
       .IsDependentOn("Pack")
       .IsDependentOn("PublishNuget")
       .IsDependentOn("PublishGithub");

RunTarget(target);