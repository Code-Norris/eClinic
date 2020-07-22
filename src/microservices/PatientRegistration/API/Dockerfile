FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY . /src

WORKDIR /src/API

RUN dotnet restore

RUN dotnet publish -c Release -o ./publish

WORKDIR /src/API/publish

# Copy everything else and build
#COPY . ./
#RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /src/API/publish /app
ENTRYPOINT ["dotnet", "eClinic.PatientRegistration.API.dll"]