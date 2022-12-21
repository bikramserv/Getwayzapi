# Getwayzapi ,To build api controller with "Create a web API with ASP.NET Core" 

# Developing locally with dependencies in docker-compose

Run Postgres

```
$ cd src
$ docker-compose up -d
```

You can now run/debug Getwayzapi project in Visual Studio / VS Code / Rider. (use Play Button in VS code or Build and Run with "Ctrl+F5"

Note: Swagger will be Launched with URL "https://localhost:7203/swagger/index.html" where all api functionality shown which can be tested.

# Creating EF Migrations

### Install the EF Core console tools

```
dotnet tool install --global dotnet-ef
```

### Execute the creation command

```
