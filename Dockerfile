# Use the latest version of the .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app

COPY Blog_api.csproj ./
RUN dotnet restore 

# Copy the remaining files to the container
COPY . ./

# Publish the application
RUN dotnet publish Blog_api.csproj -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 8080
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT [ "dotnet", "Blog_api.dll" ]