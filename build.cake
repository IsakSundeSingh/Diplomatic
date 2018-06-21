
///////////////////////////////////////////////////////////////////////////
// Load additional cake addins
///////////////////////////////////////////////////////////////////////////

#tool "xunit.runner.console"

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Arguments.
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

// Define directories
var solutionFile = GetFiles("./*.sln").First();
var testsDllPath = string.Format("./Diplomatic.Tests/bin/{0}/*.Tests.dll", configuration);

// Output folders
var artifactsDirectory = Directory("./Artifacts");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
	.Does(() => 
	{
		CleanDirectory(artifactsDirectory);
		CleanDirectories("./**/bin/**");
		CleanDirectories("./**/obj/**");
	});


Task("Restore-Packages")
	.Does(() => 
	{
		NuGetRestore(solutionFile);
	});


Task("Build-All")
    .IsDependentOn("Prepare-Build")
	.Does(() => 
	{
		MSBuild (solutionFile, settings => settings
            .SetConfiguration("Release")
            .SetVerbosity(Verbosity.Minimal)
            .WithProperty("TreatWarningsAsErrors", "true"));
	});


Task("Run-Tests")
	.IsDependentOn("Prepare-Build")
	.Does(() =>
	{		
		XUnit2(testsDllPath, new XUnit2Settings {
				XmlReport = true,
				OutputDirectory = artifactsDirectory
			});		
    });

Task("Prepare-Build")
	.IsDependentOn("Clean")
	.IsDependentOn("Restore-Packages")
    	.Does (() => {});


Task("Default")
    .IsDependentOn("Build-All")
    .IsDependentOn("Run-Tests");

RunTarget(target);