using SharpDBeaver.Interfaces;

namespace SharpDBeaver.Services;

public class CommandLineParser : ICommandLineParser
{
    public Dictionary<string, string> Parse(string[] args)
    {
        var result = new Dictionary<string, string>();
        
        if (args == null || !args.Any())
            return result;

        foreach (var entry in args.Select((value, index) => new { index, value }))
        {
            string argument = entry.value.ToUpper();

            switch (argument)
            {
                case "-C":
                case "/C":
                    if (entry.index + 1 < args.Length)
                        result["config"] = args[entry.index + 1];
                    break;
                case "-S":
                case "/S":
                    if (entry.index + 1 < args.Length)
                        result["sources"] = args[entry.index + 1];
                    break;
            }
        }
        
        return result;
    }
} 
