namespace SharpDBeaver.Interfaces;

public interface IPathResolver
{
    string GetAppDataFolderPath();
    string CombinePaths(params string[] parts);
} 
