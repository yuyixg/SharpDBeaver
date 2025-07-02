using SharpDBeaver.Interfaces;

namespace SharpDBeaver.Services;

public class DefaultPathResolver : IPathResolver
{
    public string GetAppDataFolderPath()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    }

    public string CombinePaths(params string[] parts)
    {
        return Path.Combine(parts);
    }
} 
