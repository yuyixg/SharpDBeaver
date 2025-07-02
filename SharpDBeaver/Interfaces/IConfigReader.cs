namespace SharpDBeaver.Interfaces;

public interface IConfigReader
{
    string ReadConfig(string filePath, string keyHex, string ivHex);
} 
