// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.IO;
using ADotNet.Clients.Builders;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;

namespace ARK.Core.Infrastructure.Builds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string buildScriptPath =
                "../../../../.github/workflows/dotnet.yml";

            string directoryPath =
                Path.GetDirectoryName(buildScriptPath);

            if(Directory.Exists(directoryPath) is false)
            {
                Directory.CreateDirectory(directoryPath);
            }

            GitHubPipelineBuilder.CreateNewPipeline()
                .SetName("ARK Core API Build")
                    .OnPush("master")
                    .OnPullRequest("master")
                        .AddJob("build", job => job
                        .WithName("Build")
                        .RunsOn(BuildMachines.Windows2022)
                            .AddCheckoutStep("Check out")
                            .AddSetupDotNetStep(version: "9.0.101")
                            .AddRestoreStep()
                            .AddBuildStep()
                            .AddTestStep(
                                command: "dotnet test --no-build --verbosity normal --filter " +
                                    "'FullyQualifiedName!~Integrations'"))

            .SaveToFile(buildScriptPath);
        }
    }
}
