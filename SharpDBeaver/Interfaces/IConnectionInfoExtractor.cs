using SharpDBeaver.Models;

namespace SharpDBeaver.Interfaces;

public interface IConnectionInfoExtractor
{
    IEnumerable<ConnectionInfo> ExtractConnections(string configContent);
} 
