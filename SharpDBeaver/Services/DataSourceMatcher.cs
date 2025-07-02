using System.Text.RegularExpressions;
using SharpDBeaver.Interfaces;

namespace SharpDBeaver.Services;

public class DataSourceMatcher : IDataSourceMatcher
{
    public string? GetConnectionUrl(string sourcesContent, string jdbcKey)
    {
        string pattern = $@"\""({Regex.Escape(jdbcKey)})\""\s*:\s*\{{[^}}]+\}}url\""\s*:\s*\""([^\""]+)\""[^}}]+\}}";
        Match match = Regex.Match(sourcesContent, pattern);
        
        return match.Success ? match.Groups[2].Value : null;
    }
} 
