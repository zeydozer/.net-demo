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
dotnet add BankApp.Application package Dapper
dotnet add BankApp.Application package Microsoft.Data.Sqlite
dotnet add BankApp.Infrastructure package Microsoft.EntityFrameworkCore
dotnet add BankApp.Infrastructure package Microsoft.EntityFrameworkCore.SqlServer
dotnet add BankApp.Infrastructure package Microsoft.EntityFrameworkCore.InMemory
dotnet add BankApp.Infrastructure package Dapper
dotnet add BankApp.Infrastructure package Microsoft.EntityFrameworkCore.Design
dotnet add BankApp.Api package Serilog.AspNetCore
dotnet add BankApp.Api package MediatR
dotnet add BankApp.Api package Microsoft.EntityFrameworkCore.Sqlite
dotnet add BankApp.Api package Microsoft.EntityFrameworkCore.Design

REM === EF Core migration & DB update ===
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate --project BankApp.Infrastructure/BankApp.Infrastructure.csproj --startup-project BankApp.Api/BankApp.Api.csproj
dotnet ef database update --project BankApp.Infrastructure/BankApp.Infrastructure.csproj --startup-project BankApp.Api/BankApp.Api.csproj

echo Backend skeleton created.