using SharpDBeaver.Interfaces;
using SharpDBeaver.Models;

namespace SharpDBeaver.Services;

public class ConnectionProcessor
{
    private readonly IConfigReader _configReader;
    private readonly IConnectionInfoExtractor _connectionInfoExtractor;
    private readonly IDataSourceMatcher _dataSourceMatcher;
    private readonly IConnectionInfoPrinter _connectionInfoPrinter;

    public ConnectionProcessor(
        IConfigReader configReader,
        IConnectionInfoExtractor connectionInfoExtractor,
        IDataSourceMatcher dataSourceMatcher,
        IConnectionInfoPrinter connectionInfoPrinter)
    {
        _configReader = configReader;
        _connectionInfoExtractor = connectionInfoExtractor;
        _dataSourceMatcher = dataSourceMatcher;
        _connectionInfoPrinter = connectionInfoPrinter;
    }

    public void ProcessConnections(string configPath, string sourcesPath)
    {
        string configContent = _configReader.ReadConfig(configPath, "babb4a9f774ab853c96c2d653dfe544a", "00000000000000000000000000000000");
        string sourcesContent = File.ReadAllText(sourcesPath);
        
        var connections = _connectionInfoExtractor.ExtractConnections(configContent);
        
        foreach (var connection in connections)
        {
            string? url = _dataSourceMatcher.GetConnectionUrl(sourcesContent, connection.Key);
            string displayUrl = url ?? $"No matching connection found for {connection.Key}";
            _connectionInfoPrinter.PrintConnectionInfo(connection, displayUrl);
        }
    }
} 
