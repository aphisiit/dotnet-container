# WebAPI

## Install ef tool for manage database
```sh
dotnet tool install --global dotnet-ef
```
Add Ngsql package for PostgreSQL Database
```sh
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```
```sh
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL.Design
```
Add Entity core Design
```sh
dotnet add package Microsoft.EntityFrameworkCore.Design
```
Add Naming Convention
```sh
dotnet add package EFCore.NamingConventions
```

Use this command to create model and DBContext from exited database.
```sh
dotnet ef dbcontect scaffold \
    "Host=localhost;Port=5432;Database=test;Username=admin;Password=admin" \
    Npgsql.EntityFrameworkCore.PostgreSQL
```
With specify path
```sh
dotnet ef dbcontext scaffold \
    "Host=localhost;Port=5432;Database=test;Username=admin;Password=admin" \
    Npgsql.EntityFrameworkCore.PostgreSQL \
    --context TestDbContext \
    --context-namespace ScaffoldPostgresql.PostgreSQL \
    --context-dir PostgreSQL \
    --namespace ScaffoldPostgresql.Models \
    --output-dir Models \
    --no-onconfiguring \
    --force
```

## Install Serilog for Log Pattern
Core Function
```sh
dotnet add package Serilog.AspNetCore
```
Console
```sh
dotnet add package Serilog.Sinks.Console
```