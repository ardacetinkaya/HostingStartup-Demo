Write-Host "Generating external HostingStartup for Web Application"
if ($IsWindows) {
    Write-Host "Packaging for Windows OS"
    dotnet build ..\HostingStartupExternalLibrary\HostingStartupExternalLibrary.csproj
    dotnet publish ..\HostingStartupExternalLibrary\HostingStartupExternalLibrary.csproj -r win-x64

    New-Item -ItemType Directory -Force -Path "C:\SomeCompany\"

    Copy-Item "..\HostingStartupExternalLibrary\bin\Debug\net5.0\publish\HostingStartupExternalLibrary.dll" -Destination "C:\SomeCompany\"
}
else{
    Write-Host "Packaging for other OS"
}

