using SharpDBeaver.Interfaces;
using SharpDBeaver.Services;
using Microsoft.Extensions.DependencyInjection;

namespace SharpDBeaver;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var serviceProvider = ServiceContainer.BuildServiceProvider();
            
            var pathResolver = serviceProvider.GetRequiredService<IPathResolver>();
            var commandLineParser = serviceProvider.GetRequiredService<ICommandLineParser>();
            var connectionProcessor = serviceProvider.GetRequiredService<ConnectionProcessor>();

            var parsedArgs = commandLineParser.Parse(args);
            
            string? configPath = parsedArgs.GetValueOrDefault("config");
            string? sourcesPath = parsedArgs.GetValueOrDefault("sources");

            if (!parsedArgs.Any())
            {
                sourcesPath = pathResolver.CombinePaths(
                    pathResolver.GetAppDataFolderPath(), 
                    "DBeaverData", 
                    "workspace6", 
                    "General", 
                    ".dbeaver", 
                    "data-sources.json");
                
                string defaultConfigPath = pathResolver.CombinePaths(
                    pathResolver.GetAppDataFolderPath(), 
                    "DBeaverData", 
                    "workspace6", 
                    "General", 
                    ".dbeaver", 
                    "credentials-config.json");
                
                connectionProcessor.ProcessConnections(defaultConfigPath, sourcesPath);
            }
            else if (!string.IsNullOrEmpty(sourcesPath) && !string.IsNullOrEmpty(configPath))
            {
                connectionProcessor.ProcessConnections(configPath, sourcesPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
