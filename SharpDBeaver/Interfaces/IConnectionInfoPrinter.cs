using SharpDBeaver.Models;

namespace SharpDBeaver.Interfaces;

public interface IConnectionInfoPrinter
{
    void PrintConnectionInfo(ConnectionInfo connection, string url);
} 
