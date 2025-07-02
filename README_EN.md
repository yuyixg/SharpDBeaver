# SharpDBeaver

## Introduction

DBeaver Database Password Decryption Tool - .NET 8 Refactored Version with AOT Compilation Support

Original Project: https://github.com/lele8/SharpDBeaver

**This is a .NET 8 refactored version of the original project, completely rewritten with AOT compilation support, following SOLID principles**

## Technical Features

- **.NET 8**: Uses the latest .NET 8 framework for better performance and security
- **SOLID Principles**: Code completely refactored following SOLID principles with clear separation of concerns and maintainability
- **Dependency Injection**: Uses Microsoft.Extensions.DependencyInjection for loose coupling architecture
- **AOT Compilation**: Supports Ahead-of-Time compilation, generating a single executable file without runtime dependencies
- **Clean Code**: Follows DRY principle with concise methods and high code readability

## Project Structure

```
SharpDBeaver/
├── Interfaces/          # Interface definitions
├── Models/             # Data models
├── Services/           # Service implementations
└── Program.cs          # Program entry point
```

## Usage Instructions

### Standard Compilation Version
```bash
dotnet build
dotnet run
```

### AOT Compilation Version (Recommended)

#### Windows
```bash
# Using build script
build.bat

# Or manual execution
dotnet publish -c Release
# Generates single executable: bin/Release/net8.0/win-x64/publish/SharpDBeaver.exe
```

#### Linux/macOS
```bash
# Using build script
chmod +x build.sh
./build.sh

# Or manual execution
dotnet publish -c Release
# Generates single executable: bin/Release/net8.0/linux-x64/publish/SharpDBeaver
```

### Command Line Parameters
```
SharpDBeaver.exe
SharpDBeaver.exe -c credentials-config.json -s data-sources.json
```

![](./img/test.png)

## Disclaimer

This tool is intended for **legally authorized** enterprise security construction activities only. If you need to test the usability of this tool, please set up your own target environment.

When using this tool, you should ensure that such behavior complies with local laws and regulations and that you have obtained sufficient authorization. **Please do not attack unauthorized targets.**

**If you engage in any illegal activities while using this tool, you will bear the corresponding consequences, and the author will not bear any legal or joint liability.**

Before installing and using this tool, please **carefully read and fully understand all terms and conditions**. Limitations, disclaimers, or other terms involving your significant rights may be highlighted in bold, underlined, or other forms to draw your attention. Unless you have fully read, completely understood, and accepted all terms of this agreement, please do not install and use this tool. Your use of this tool or any other express or implied indication of your acceptance of this agreement shall be deemed as your reading and agreement to be bound by this agreement. 
