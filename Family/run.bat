"%ProgramFiles%\dotnet\dotnet.exe" clean
"%ProgramFiles%\dotnet\dotnet.exe" build
"%ProgramFiles%\dotnet\dotnet.exe" test ../Family.Tests
"%ProgramFiles%\dotnet\dotnet.exe" run --project ../Family
PAUSE