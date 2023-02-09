# Dotnet Container

Restore .NET project
```sh
dotnet restore
```
Start app
```sh
dotnet run --project webapi
```
You can goto http://localhost:9090/swagger/index.html for view result. But this application is not complete because it no Database. If you want to test with Database, you must use docker instead.

Build image 
```sh
docker build -t web-api .
```

Start completed with docker compose
```sh
docker compose up -d
```

Rebuild webapi container
```
docker compose up -d dotnet-api --build
```