# Use the official .NET 8 runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Set the working directory
WORKDIR /app

# Copy the compiled application
COPY ./out .

# Specify the entry point
ENTRYPOINT ["dotnet", "bookstore.dll"]