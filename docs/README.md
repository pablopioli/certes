# Certes

Certes is an [ACME](https://en.wikipedia.org/wiki/Automated_Certificate_Management_Environment)
client that runs on .NET 4.6+, .NET Standard 2.0+ and .NET 6+.

This is a fork of the original code from https://github.com/fszlin/certes. The only change is added compatibility with native AOT in .NET 8+.

**See the original project documentation to learn how to use this library.**

## Usage

Install the nuget package into your project:
```PowerShell
Install-Package PPioli.Certes.AOT
```
or using .NET CLI:
```DOS
dotnet add package PPioli.Certes.AOT
```