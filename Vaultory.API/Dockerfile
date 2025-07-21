# Use the official .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy project files
COPY *.sln .
COPY Vaultory.API/*.csproj ./Vaultory.API/
COPY Vaultory.Application/*.csproj ./Vaultory.Application/
COPY Vaultory.Infrastructure/*.csproj ./Vaultory.Infrastructure/
COPY Vaultory.Domain/*.csproj ./Vaultory.Domain/

# Restore dependencies
RUN dotnet restore

# Copy everything else and build
COPY . .
WORKDIR /app/Vaultory.API
RUN dotnet publish -c Release -o out

# Use a runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/Vaultory.API/out ./
ENTRYPOINT ["dotnet", "Vaultory.API.dll"]
