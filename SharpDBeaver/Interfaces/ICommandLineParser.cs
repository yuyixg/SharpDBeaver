namespace SharpDBeaver.Interfaces;

public interface ICommandLineParser
{
    Dictionary<string, string> Parse(string[] args);
} 
