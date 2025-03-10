# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copy the solution file and the .csproj file from the nested MovieAPI folder to the build container
COPY MovieAPI/*.csproj ./

# Restore any dependencies (via NuGet)
RUN dotnet restore

# Copy the rest of the code from the nested MovieAPI folder to the build container
COPY MovieAPI/. ./

# Publish the app to the /out folder
RUN dotnet publish -c Release -o /out

# Now, use the runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

# Copy the SQLite database file (movies.db) from the nested Data folder to the container
COPY MovieAPI/Data/movies.db /app/Data/movies.db

# Copy the published app from the build container
COPY --from=build /out .

# Expose the port the app will run on
EXPOSE 80

# Set the entry point for the application to start the app
ENTRYPOINT ["dotnet", "MovieAPI.dll"]
