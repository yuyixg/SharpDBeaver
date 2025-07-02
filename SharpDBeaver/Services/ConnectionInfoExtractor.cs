using System.Text.RegularExpressions;
using SharpDBeaver.Interfaces;
using SharpDBeaver.Models;

namespace SharpDBeaver.Services;

public class ConnectionInfoExtractor : IConnectionInfoExtractor
{
    public IEnumerable<ConnectionInfo> ExtractConnections(string configContent)
    {
        var connections = new List<ConnectionInfo>();
        
        string pattern = @"\""(?<key>[^\""]+)\""\s*:\s*\{\s*\""#connection\""\s*:\s*\{\s*\""user\""\s*:\s*\""(?<user>[^\""]+)\""\s*,\s*\""password\""\s*:\s*\""(?<password>[^\""]+)\""\s*\}\s*\}";
        MatchCollection matches = Regex.Matches(configContent, pattern);
        
        foreach (Match match in matches)
        {
            connections.Add(new ConnectionInfo
            {
                Key = match.Groups["key"].Value,
                User = match.Groups["user"].Value,
                Password = match.Groups["password"].Value
            });
        }
        
        return connections;
    }
} 
