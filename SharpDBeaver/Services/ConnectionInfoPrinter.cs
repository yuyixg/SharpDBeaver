using SharpDBeaver.Interfaces;
using SharpDBeaver.Models;

namespace SharpDBeaver.Services;

public class ConnectionInfoPrinter : IConnectionInfoPrinter
{
    public void PrintConnectionInfo(ConnectionInfo connection, string url)
    {
        Console.WriteLine($"username: {connection.User}");
        Console.WriteLine($"password: {connection.Password}");
        Console.WriteLine($"host: {url}");
        Console.WriteLine();
    }
} 
