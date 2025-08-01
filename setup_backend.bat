@echo off
REM === Create solution & projects ===
dotnet new sln -n BankApp
dotnet new webapi -n BankApp.Api
dotnet new classlib -n BankApp.Application
dotnet new classlib -n BankApp.Domain
dotnet new classlib -n BankApp.Infrastructure
dotnet sln add BankApp.*\*

dotnet add BankApp.Api reference BankApp.Domain
dotnet add BankApp.Api reference BankApp.Infrastructure
dotnet add BankApp.Api reference BankApp.Application
dotnet add BankApp.Infrastructure reference BankApp.Domain
dotnet add BankApp.Application reference BankApp.Domain
dotnet add BankApp.Application reference BankApp.Infrastructure

REM === NuGet packages ===
dotnet add BankApp.Application package MediatR --prerelease
dotnet add BankApp.Application package FluentValidation
dotnet add BankApp.Infrastructure package Microsoft.EntityFrameworkCore
dotnet add BankApp.Infrastructure package Microsoft.EntityFrameworkCore.SqlServer
dotnet add BankApp.Infrastructure package Microsoft.EntityFrameworkCore.InMemory
dotnet add BankApp.Infrastructure package Dapper
dotnet add BankApp.Api package Serilog.AspNetCore
dotnet add BankApp.Api package MediatR

echo Backend skeleton created.