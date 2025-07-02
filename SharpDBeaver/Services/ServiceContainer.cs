using Microsoft.Extensions.DependencyInjection;
using SharpDBeaver.Interfaces;
using SharpDBeaver.Services;

namespace SharpDBeaver.Services;

public static class ServiceContainer
{
    public static IServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();
        
        // 注册接口和实现
        services.AddSingleton<IPathResolver, DefaultPathResolver>();
        services.AddSingleton<IConfigReader, ConfigReader>();
        services.AddSingleton<IConnectionInfoExtractor, ConnectionInfoExtractor>();
        services.AddSingleton<IDataSourceMatcher, DataSourceMatcher>();
        services.AddSingleton<IConnectionInfoPrinter, ConnectionInfoPrinter>();
        services.AddSingleton<ICommandLineParser, CommandLineParser>();
        services.AddSingleton<ConnectionProcessor>();
        
        return services.BuildServiceProvider();
    }
} 
