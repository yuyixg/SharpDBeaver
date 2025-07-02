namespace SharpDBeaver.Interfaces;

public interface IDataSourceMatcher
{
    string? GetConnectionUrl(string sourcesContent, string jdbcKey);
} 
