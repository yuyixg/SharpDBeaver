@echo off
echo Building SharpDBeaver for .NET 8 with AOT support...

echo.
echo 1. Restoring packages...
dotnet restore

echo.
echo 2. Building in Release mode...
dotnet build -c Release

echo.
echo 3. Publishing with AOT compilation...
dotnet publish -c Release

echo.
echo Build completed successfully!
echo AOT compiled executable: bin\Release\net8.0\win-x64\publish\SharpDBeaver.exe
echo.
pause 
